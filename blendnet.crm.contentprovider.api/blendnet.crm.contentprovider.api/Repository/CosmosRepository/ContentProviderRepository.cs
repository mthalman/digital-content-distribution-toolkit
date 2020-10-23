﻿using blendnet.crm.contentprovider.api.Model;
using blendnet.crm.contentprovider.api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blendnet.crm.contentprovider.api.Repository.CosmosRepository
{
    /// <summary>
    /// Repository implementation
    /// </summary>
    public class ContentProviderRepository : IContentProviderRepository
    {
        private BlendNetContext _blendNetContext;

        public ContentProviderRepository(BlendNetContext blendNetContext)
        {
            _blendNetContext = blendNetContext;
        }

        #region Content Provider Methods
        /// <summary>
        /// Creates the content provider
        /// </summary>
        /// <param name="contentProvider"></param>
        /// <returns></returns>
        public async Task<Guid> CreateContentProvider(ContentProvider contentProvider)
        {
            contentProvider.ResetIdentifiers();

            _blendNetContext.ContentProviders.Add(contentProvider);

            await _blendNetContext.SaveChangesAsync();

            return contentProvider.Id.Value;
        }

        /// <summary>
        /// Get the content provider by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ContentProvider> GetContentProviderById(Guid id)
        {
            return _blendNetContext.ContentProviders.Where(cp => cp.Id == id).AsNoTracking().FirstOrDefault();
        }

        /// <summary>
        /// Return the content providers
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentProvider>> GetContentProviders()
        {
            return await _blendNetContext.ContentProviders.ToListAsync();
        }

        /// <summary>
        /// Updates Content Provider
        /// </summary>
        /// <param name="updatedContentProvider"></param>
        /// <returns></returns>
        public async Task<int> UpdateContentProvider(ContentProvider updatedContentProvider)
        {
            int recordsAffected = 0;

            ContentProvider existingProvider = await GetContentProviderById(updatedContentProvider.Id.Value);

            if (existingProvider != default(ContentProvider))
            {
                var updatedContentProviderEntry = _blendNetContext.Add(updatedContentProvider);

                updatedContentProviderEntry.State = EntityState.Unchanged;

                _blendNetContext.ContentProviders.Update(updatedContentProvider);

                recordsAffected = await _blendNetContext.SaveChangesAsync();
            }
            
            return recordsAffected;
        }

        /// <summary>
        /// Deletes Content Provider
        /// </summary>
        /// <param name="contentProviderId"></param>
        /// <returns></returns>
        public async Task<int> DeleteContentProvider(Guid contentProviderId)
        {
            int recordsAffected = 0;

            ContentProvider existingProvider = await GetContentProviderById(contentProviderId);

            if (existingProvider != default(ContentProvider))
            {
                var deleteContentProviderEntry = _blendNetContext.Add(existingProvider);

                deleteContentProviderEntry.State = EntityState.Unchanged;

                _blendNetContext.ContentProviders.Remove(existingProvider);

                recordsAffected = await _blendNetContext.SaveChangesAsync();
            }

            return recordsAffected;
        }

        #endregion
    }
}
