﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace blendnet.common.dto.Incentive
{
    public class IncentiveEvent : BaseDto
    {
        /// <summary>
        /// Unique event id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid? EventId { get; set; }

        /// <summary>
        /// User phone number of consumer or Partner id of retailer
        /// </summary>
        public string EventCreatedFor { get; set; }

        /// <summary>
        /// Event type of the event
        /// </summary>
        public EventType EventType { get; set; }

        /// <summary>
        /// Content provider id in case of order completed event
        /// </summary>
        public string EventSubType { get; set; }

        /// <summary>
        /// List of additional parameters that can be sent
        /// </summary>
        public List<Property> Properties { get; set; }

        /// <summary>
        /// Time during which event was created. Might differ than CreatedDate when event is 
        /// called from client and there are network delays
        /// </summary>
        public DateTime EventOccuranceTime { get; set; }

        /// <summary>
        /// EventOccurance time represented in int format
        /// </summary>
        public int EventOccuranceDate => Int32.Parse(EventOccuranceTime.ToString(ApplicationConstants.DateTimeFormats.FormatYYYYMMDD));

        /// <summary>
        /// Computed Value of the event which is later used for computation
        /// </summary>
        public double CalculatedValue { get; set; }

        /// <summary>
        /// Original Value of the event which is later used for reference
        /// </summary>
        public double OriginalValue { get; set; }

        /// <summary>
        /// Category of the event indicating whether it is an income event or expense event
        /// </summary>
        public EventCategoryType EventCategoryType { get; set; }

        /// <summary>
        /// Target audience of event. Useful when getting overall summary based on audience
        /// </summary>
        public Audience Audience { get; set; }

    }

    public class Property
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventCategoryType
    {
        INCOME,
        EXPENSE
    }
}
