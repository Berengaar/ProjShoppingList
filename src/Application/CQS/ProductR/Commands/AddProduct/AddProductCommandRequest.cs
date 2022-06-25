﻿using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.AddProduct
{
    public class AddProductCommandRequest : IRequest<CommandResponse>
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public UnitProduct Unit { get; set; }
        public int StockAmount { get; set; }
    }
}
