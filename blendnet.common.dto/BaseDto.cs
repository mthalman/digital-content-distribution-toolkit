﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blendnet.common.dto
{
    /// <summary>
    /// Base DTO for all the objects
    /// </summary>
    public class BaseDto
    {
        public Guid CreatedByUserId { get; set; }

        public Guid? ModifiedByByUserId { get; set; }

    }
}
