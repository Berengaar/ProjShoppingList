﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Description { get; set; }

    }
}