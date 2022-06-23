﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShopList : BaseEntity
    {
        public string Type { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}