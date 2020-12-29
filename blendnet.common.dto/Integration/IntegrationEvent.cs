﻿using System;
using System.Collections.Generic;
using System.Text;

namespace blendnet.common.dto.Integration
{
    /// <summary>
    /// Base Class for all the integration Events
    /// </summary>
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
        
        /// <summary>
        /// Event Id
        /// </summary>
        public Guid Id { get; private set; }


        /// <summary>
        /// Name of the event
        /// </summary>
        public string  EventName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        /// <summary>
        /// Creation Date of Event
        /// </summary>
        public DateTime CreationDate { get; private set; }
    }
}