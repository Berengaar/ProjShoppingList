﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.BuyProduct
{
    public class BuyProductCommandRequest : IRequest<CommandResponse>
    {
        public string Id { get; set; }
    }
}
