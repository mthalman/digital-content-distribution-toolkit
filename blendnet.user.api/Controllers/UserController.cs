﻿using blendnet.api.proxy.Retailer;
using blendnet.common.dto;
using blendnet.common.dto.Events;
using blendnet.common.dto.Retailer;
using blendnet.common.dto.User;
using blendnet.common.infrastructure;
using blendnet.common.infrastructure.Authentication;
using blendnet.user.api.Models;
using blendnet.user.repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace blendnet.user.api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;

        private IUserRepository _userRepository;

        private RetailerProxy _retailerProxy;

        private IEventBus _eventBus;

        private UserAppSettings _appSettings;

        public UserController(IUserRepository userRepository,
                              ILogger<UserController> logger,
                              RetailerProxy retailerProxy,
                              IEventBus eventBus,
                              IOptionsMonitor<UserAppSettings> optionsMonitor)
        {
            _logger = logger;
            _userRepository = userRepository;
            _retailerProxy = retailerProxy;
            _eventBus = eventBus;
            _appSettings = optionsMonitor.CurrentValue;
        }

        /// <summary>
        /// Create BlendNet User
        /// </summary>
        /// <param name="User"></param>
        /// <returns>Status</returns>
        [HttpPost("createuser", Name = nameof(CreateUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> CreateUser(CreateUserRequest request)
        {
            List<string> errorInfo = new List<string>();

            Guid userId = UserClaimData.GetUserId(User.Claims);
            String phoneNumber = this.User.Identity.Name;

            if (await _userRepository.GetUserByPhoneNumber(phoneNumber) != null)
            {
                errorInfo.Add($"User Already exists in the system {phoneNumber}");
                return BadRequest(errorInfo);
            }

            User user = new User
            {
                    Id = userId, 
                    PhoneNumber = phoneNumber, 
                    UserName = request.UserName,
                    ChannelId = request.ChannelId,
                    CreatedDate = DateTime.UtcNow,
                    CreatedByUserId = userId
            };

            await _userRepository.CreateUser(user);

            return Ok(user.Id);
        }

        /// <summary>
        /// Creates a new retailer - to be called by partner
        /// </summary>
        /// <param name="retailerRequest">Request containg retailer details</param>
        /// <returns>Retailer ID of the created retailer</returns>
        [HttpPost("createretailer")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [AuthorizeRoles(ApplicationConstants.KaizalaIdentityRoles.RetailerManagement)]
        public async Task<ActionResult<string>> CreateRetailer(CreateRetailerRequest retailerRequest)
        {
            string partnerCode = UserClaimData.GetPartnerCode(this.User.Claims, _appSettings.ServiceIdMapping);
            
            return await this.CreateRetailerInternal(retailerRequest, partnerCode);
        }

        /// <summary>
        /// Creates a new retailer - to be called by Super Admin
        /// </summary>
        /// <param name="retailerRequest">Request containg retailer details</param>
        /// <returns>Retailer ID of the created retailer</returns>
        [HttpPost("CreateRetailerAsSuperAdmin")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        [AuthorizeRoles(ApplicationConstants.KaizalaIdentityRoles.SuperAdmin)]
        public async Task<ActionResult<string>> CreateRetailerAsSuperAdmin(string partnerCode, CreateRetailerRequest retailerRequest)
        {
            return await this.CreateRetailerInternal(retailerRequest, partnerCode);
        }

        /// <summary>
        /// Get user using phone number
        /// </summary>
        /// <param name="User"></param>
        /// <returns>User Object</returns>
        [HttpGet("getuser/{phoneNumber}", Name = nameof(GetUserByPhoneNumber))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [AuthorizeRoles(ApplicationConstants.KaizalaIdentityRoles.SuperAdmin)]
        public async Task<ActionResult<User>> GetUserByPhoneNumber(string phoneNumber)
        {
            User user = await _userRepository.GetUserByPhoneNumber(phoneNumber);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        /// <summary>
        /// Get current user details
        /// </summary>
        /// <param name="User"></param>
        /// <returns>User Object</returns>
        [HttpGet("getuser", Name = nameof(GetUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<User>> GetUser()
        {
            List<string> errorInfo = new List<string>();
            return await GetUserByPhoneNumber(this.User.Identity.Name);
        }

        /// <summary>
        /// Assign Retailer(Referral) data  to the Customer
        /// </summary>
        /// <param name="referralDto"></param>
        /// <returns>/returns>
        [HttpPost("assignretailer/{refferalCode}", Name = nameof(AssignRetailer))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<User>> AssignRetailer(string refferalCode)
        {
            List<string> errorInfo = new List<string>();

            String phoneNumber = this.User.Identity.Name;
            User user = await _userRepository.GetUserByPhoneNumber(phoneNumber);
            if (user == null)
            {
                errorInfo.Add($"No valid details found for current user {phoneNumber}");
                return NotFound(errorInfo);
            }

            if (user.ChannelId != Channel.ConsumerApp)
            {
                errorInfo.Add("Only Customers are allowerd to enter referral info");
                return BadRequest(errorInfo);
            }

            if (user.ReferralInfo != null)
            {
                errorInfo.Add("ReferralCode is already assigned");
                return BadRequest(errorInfo);
            }

            RetailerDto retailerDto = await _retailerProxy.GetRetailerByReferralCode(refferalCode);
            if(retailerDto == null)
            {
                errorInfo.Add("Invalid referral code");
                return BadRequest(errorInfo);
            }

            var currentDate = DateTime.UtcNow;
            user.ReferralInfo = new ReferralDto
            {
                RetailerId = retailerDto.Id,
                RetailerPartnerId = retailerDto.PartnerId,
                RetailerReferralCode = retailerDto.ReferralCode,
                ReferralDate = Int32.Parse(currentDate.ToString(ApplicationConstants.DateTimeFormats.FormatYYYYDDMM)),
                ReferralDateTime = currentDate,
            };

            user.ModifiedByByUserId = UserClaimData.GetUserId(User.Claims);
            user.ModifiedDate = currentDate;

            int statusCode = await _userRepository.UpdateUser(user);
            if (statusCode == (int)System.Net.HttpStatusCode.OK)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("summary/{retailerPartnerId}", Name = nameof(GetReferralSummary))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> GetReferralSummary(string retailerPartnerId, int startDate, int endDate)
        {
            List<string> errorDetails = new List<string>();

            if (startDate <= 0 || endDate <= 0)
            {
                errorDetails.Add("Invalid start or end date");
                return BadRequest(errorDetails);
            }

            if (startDate > endDate)
            {
                errorDetails.Add("Invalid date range");
                return BadRequest(errorDetails);
            }

            List<ReferralSummary> referralData = await _userRepository.GetReferralSummary(retailerPartnerId, startDate, endDate);
            if (referralData == null || referralData.Count == 0)
            {
                return NotFound();
            }

            return Ok(referralData);
        }

        #region private methods
        /// <summary>
        /// Validate Retailer referral info
        /// </summary>
        /// <param name="ReferralDto"></param>
        /// <returns>Success/Fail</returns>
        private bool ValidateReferralData(ReferralDto referralDto)
        {
            //TODO: Validation check to be implemented
            return true;
        }

        /// <summary>
        /// Creates the user, if not already exists
        /// </summary>
        /// <param name="user">user to be created</param>
        /// <returns>true if the user was created, false otherwise</returns>
        private async Task<bool> CreateUserIfNotExist(User user)
        {
            if (await _userRepository.GetUserByPhoneNumber(user.PhoneNumber) == null)
            {
                await _userRepository.CreateUser(user);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Logic for creating retailer from the request
        /// </summary>
        /// <param name="retailerRequest">request</param>
        /// <param name="partnerCode">Partner Code</param>
        /// <returns>Retailer ID of the created retailer</returns>
        private async Task<ActionResult<string>> CreateRetailerInternal(CreateRetailerRequest retailerRequest, string partnerCode)
        {
            Guid callerUserId = UserClaimData.GetUserId(User.Claims);

            // validations
            {
                var listOfValidationErrors = new List<string>();

                if (!RetailerDto.IsPartnerCodeValid(partnerCode, _appSettings.ServiceIdMapping))
                {
                    listOfValidationErrors.Add($"Invalid partner code : {partnerCode}");
                }

                string phoneNumber = retailerRequest.PhoneNumber;
                if (!common.dto.User.User.IsPhoneNumberValid(phoneNumber))
                {
                    listOfValidationErrors.Add("Invalid Phone number format");
                }

                if (!retailerRequest.Address.MapLocation.isValid())
                {
                    listOfValidationErrors.Add("Map Location is not valid");
                }

                var existingRetailer = await _retailerProxy.GetRetailerById(retailerRequest.RetailerId, partnerCode);
                if (existingRetailer != null)
                {
                    listOfValidationErrors.Add($"Retailer Already Exists ID : {retailerRequest.RetailerId}");
                }

                // check and return validation errors
                if (listOfValidationErrors.Count > 0)
                {
                    return BadRequest(listOfValidationErrors);
                }
            }

            DateTime now = DateTime.UtcNow;

            // create user if not exists
            User user = new User
            {
                Id = retailerRequest.UserId, 
                PhoneNumber = retailerRequest.PhoneNumber, 
                UserName = retailerRequest.Name,
                ChannelId = Channel.NovoRetailerApp, // TODO: this should be from the Claim / partnerCode
                CreatedDate = now,
                CreatedByUserId = callerUserId,
            };

            await this.CreateUserIfNotExist(user);

            // create RetailerDto from request
            RetailerDto retailer = new RetailerDto()
            {
                // Base propeties
                CreatedByUserId = callerUserId,
                CreatedDate = now,

                // Person Properties
                Id = retailerRequest.UserId,
                PhoneNumber = retailerRequest.PhoneNumber,
                UserName = retailerRequest.Name,

                // User properties
                // Retailer properties
                PartnerProvidedId = retailerRequest.RetailerId,
                PartnerCode = partnerCode,
                Address = retailerRequest.Address,
                Services = new List<ServiceType>() { ServiceType.Media },
                AdditionalAttibutes = retailerRequest.AdditionalAttributes,

                StartDate = now,
                EndDate = DateTime.MaxValue,
            };

            RetailerCreatedIntegrationEvent retailerCreatedIntegrationEvent = new RetailerCreatedIntegrationEvent()
            {
                Retailer = retailer,
            };

            await _eventBus.Publish(retailerCreatedIntegrationEvent);

            return Ok(retailerRequest.RetailerId);
        }

        #endregion
    }
}