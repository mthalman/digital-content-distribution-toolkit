﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blendnet.common.dto.Incentive
{
    /// <summary>
    /// Defines the audience of event or incentive plan
    /// </summary>
    public class Audience
    {
        /// <summary>
        /// Audience type
        /// </summary>
        public AudienceType AudienceType { get; set; }

        /// <summary>
        /// "Nil GUID" for Consumer, Selected RetailerProvider GUID in case of Retailer
        /// </summary>
        public Guid SubTypeId { get; set; }

        /// <summary>
        /// "All" for Consumer, Selected RP Name in case of Retailer
        /// </summary>
        public string SubTypeName { get; set; }
    }

    public enum AudienceType
    {
        CONSUMER = 0,
        RETAILER = 1
    }
}
