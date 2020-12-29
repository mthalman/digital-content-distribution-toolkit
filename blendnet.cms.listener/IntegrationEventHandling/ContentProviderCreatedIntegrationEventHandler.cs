﻿using Azure.Storage.Blobs;
using blendnet.cms.listener.Model;
using blendnet.common.dto;
using blendnet.common.dto.Events;
using blendnet.common.infrastructure;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blendnet.cms.listener.IntegrationEventHandling
{
    /// <summary>
    /// Content Provider Created Integration EventHandler
    /// 1) Responsible for creating blob storage 
    /// 2) Responsible for adding user to content administrator user group
    /// </summary>
    public class ContentProviderCreatedIntegrationEventHandler : IIntegrationEventHandler<ContentProviderCreatedIntegrationEvent>
    {
        private readonly ILogger _logger;

        private TelemetryClient _telemetryClient;

        private readonly AppSettings _appSettings;

        BlobServiceClient _blobServiceClient;

        GraphServiceClient _graphServiceClient;

        public ContentProviderCreatedIntegrationEventHandler(ILogger<ContentProviderCreatedIntegrationEventHandler> logger,
                                                             TelemetryClient tc,
                                                             BlobServiceClient blobServiceClient,
                                                             GraphServiceClient graphServiceClient,
                                                             IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _logger = logger;

            _telemetryClient = tc;

            _blobServiceClient = blobServiceClient;

            _graphServiceClient = graphServiceClient;

            _appSettings = optionsMonitor.CurrentValue;
        }

        /// <summary>
        /// Handle Content Provider Created Integration EventHandler
        /// </summary>
        /// <param name="integrationEvent"></param>
        /// <returns></returns>
        public async Task Handle(ContentProviderCreatedIntegrationEvent integrationEvent)
        {
            try
            {
                using (_telemetryClient.StartOperation<RequestTelemetry>("ContentProviderCreatedIntegrationEventHandler.Handle"))
                {
                    _logger.LogInformation($"Message Recieved for content provider id: {integrationEvent.ContentProvider.Id}");

                    _logger.LogInformation($"Creating storage containers for content provider id: {integrationEvent.ContentProvider.Id}");

                    //await CreateStorageContainers(integrationEvent);

                    if (integrationEvent.ContentProvider.ContentAdministrators != null &&
                        integrationEvent.ContentProvider.ContentAdministrators.Count > 0)
                    {
                        _logger.LogInformation($"Adding administrators to Azure AD for : {integrationEvent.ContentProvider.Id}");

                        await AddUserToAzureAD(integrationEvent);
                    }

                    _logger.LogInformation($"Message Process Completed for content provider id: {integrationEvent.ContentProvider.Id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        /// <summary>
        /// Creates the storage container if does not exists
        /// </summary>
        /// <param name="integrationEvent"></param>
        /// <returns></returns>
        public async Task CreateStorageContainers(ContentProviderCreatedIntegrationEvent integrationEvent)
        {
            try
            {
                var baseName = integrationEvent.ContentProvider.ContainerBaseName.Trim().ToLower();

                string stagingContainerName = $"{baseName}staginge";

                string mezzContainerName = $"{baseName}mezzanine";

                string processedContainerName = $"{baseName}processed";

                var containers = _blobServiceClient.GetBlobContainers(prefix: baseName);

                if (!containerExists(stagingContainerName))
                {
                    await _blobServiceClient.CreateBlobContainerAsync(stagingContainerName);
                }
                else
                {
                    _logger.LogInformation($"{stagingContainerName} already exists");
                }

                if (!containerExists(mezzContainerName))
                {
                    await _blobServiceClient.CreateBlobContainerAsync(mezzContainerName);
                }
                else
                {
                    _logger.LogInformation($"{mezzContainerName} already exists");
                }

                if (!containerExists(processedContainerName))
                {
                    await _blobServiceClient.CreateBlobContainerAsync(processedContainerName);
                }
                else
                {
                    _logger.LogInformation($"{processedContainerName} already exists");
                }

                bool containerExists(string containerName)
                {
                    return containers.Where(container => container.Name == containerName).ToList().Count > 0;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }


        /// <summary>
        /// Checks if the user is not the part of group adds it to the Azure AD
        /// </summary>
        /// <param name="integrationEvent"></param>
        /// <returns></returns>
        public async Task AddUserToAzureAD(ContentProviderCreatedIntegrationEvent integrationEvent)
        {
            string[] groups = new string[] { _appSettings.ContentAdministratorGroupId };

            foreach (ContentAdministratorDto contentAdministrator in  integrationEvent.ContentProvider.ContentAdministrators)
            {
                try
                {
                    //check if user has the membership
                    var result = await _graphServiceClient.Users[contentAdministrator.IdentityProviderId].CheckMemberGroups(groups).Request().PostAsync();

                    if (!result.ToList<string>().Contains(_appSettings.ContentAdministratorGroupId))
                    {
                        var directoryObject = new DirectoryObject
                        {
                            Id = contentAdministrator.IdentityProviderId
                        };

                        //add the user to group
                        await _graphServiceClient.Groups[groups[0]].Members.References.Request().AddAsync(directoryObject);
                    }
                    else
                    {
                        _logger.LogInformation($"User {contentAdministrator.IdentityProviderId} already exists in content administrator group");
                    }
                }
                catch(Microsoft.Graph.ServiceException serviceException)
                {
                    if (serviceException.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        _logger.LogInformation($"User {contentAdministrator.IdentityProviderId} does not exist in Azure AD B2C. - Exception details - {serviceException.ToString()}");
                    }
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
        }
    }
}