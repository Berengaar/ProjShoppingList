﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories.ProductRepo
{
    public interface IProductWriteRepository:IWriteRepository<Product>
    {
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> BuyAllProductsByShopListIdAsync(string shopListId);
        Task<bool> BuyProductById(string productId);
    }
}
