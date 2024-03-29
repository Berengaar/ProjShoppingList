﻿using Application.Common.Interfaces;
using Application.Common.Repositories.CategoryRepo;
using Application.Common.Repositories.ProductRepo;
using Application.Common.Repositories.ShopListRepo;
using Infrastructure.Persistance.Contexts;
using Infrastructure.Persistance.Repositories;
using Infrastructure.Persistance.Repositories.CategoryRepo;
using Infrastructure.Persistance.Repositories.ProductRepo;
using Infrastructure.Persistance.Repositories.ShopListRepo;
using Infrastructure.RedisCaching;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IProducer _producer;
        private readonly ProjShoppingListMsDbContext _context;
        private readonly ProjShoppingListPostgreSqlDbContext _postgreContext;
        private readonly MongoDbService _mongoDbService;
        private ProductReadRepository _productReadRepository;
        private ProductWriteRepository _productWriteRepository;
        private CategoryReadRepository _categoryReadRepository;
        private CategoryWriteRepository _categoryWriteRepository;
        private ShopListReadRepository _shopListReadRepository;
        private ShopListWriteRepository _shopListWriteRepository;
        private CategoryCacheRepository _categoryCacheRepository;

        public UnitOfWork(ProjShoppingListMsDbContext context, IDistributedCache distributedCache, IProducer producer, ProjShoppingListPostgreSqlDbContext postgreContext, MongoDbService mongoDbService)
        {
            _context = context;
            _distributedCache = distributedCache;
            _producer = producer;
            _postgreContext = postgreContext;
            _mongoDbService = mongoDbService;
        }

        public IProductReadRepository ProductReadRepository => _productReadRepository ?? (_productReadRepository = new ProductReadRepository(_context));

        public IProductWriteRepository ProductWriteRepository => _productWriteRepository ?? (_productWriteRepository = new ProductWriteRepository(_context,_mongoDbService));

        public ICategoryReadRepository CategoryReadRepository => _categoryReadRepository ?? (_categoryReadRepository = new CategoryReadRepository(_context));

        public ICategoryWriteRepository CategoryWriteRepository => _categoryWriteRepository ?? (_categoryWriteRepository = new CategoryWriteRepository(_context, _mongoDbService));


        public IShopListReadRepository ShopListReadRepository => _shopListReadRepository ?? (_shopListReadRepository = new ShopListReadRepository(_context, _distributedCache));

        public IShopListWriteRepository ShopListWriteRepository => _shopListWriteRepository ?? (_shopListWriteRepository = new ShopListWriteRepository(_context,_postgreContext,_producer, _mongoDbService));

        public ICategoryCacheRepository CategoryCacheRepository => _categoryCacheRepository ?? (_categoryCacheRepository = new RedisCaching.CategoryCacheRepository(_context, _distributedCache));

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
