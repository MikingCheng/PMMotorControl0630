﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.DataAccess.model
{
    public class MGroup
    {
        public string GroupName { get; set; }
        public Guid ProjectId { get; set; }
    }
}