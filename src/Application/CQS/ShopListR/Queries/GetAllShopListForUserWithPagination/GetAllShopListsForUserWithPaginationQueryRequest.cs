﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllShopListForUserWithPagination
{
    public class GetAllShopListsForUserWithPaginationQueryRequest
    {
        public string UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
