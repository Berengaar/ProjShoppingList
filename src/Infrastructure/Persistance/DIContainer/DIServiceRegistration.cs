﻿using Application.Common.Interfaces;
using Application.Common.Repositories.CategoryRepo;
using Application.Common.Repositories.ProductRepo;
using Application.Common.Repositories.ShopListRepo;
using Infrastructure.Identity;
using Infrastructure.Persistance.Repositories;
using Infrastructure.Persistance.Repositories.CategoryRepo;
using Infrastructure.Persistance.Repositories.ProductRepo;
using Infrastructure.Persistance.Repositories.ShopListRepo;
using Infrastructure.RabbitMq;
using Infrastructure.RedisCaching;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DIContainer
{
    public static class DIServiceRegistration
    {
        public static void AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IShopListReadRepository, ShopListReadRepository>();
            services.AddScoped<IShopListWriteRepository, ShopListWriteRepository>();
            services.AddScoped<IShopListWriteRepository, ShopListWriteRepository>();
            services.AddScoped<IUnitOfWork, Infrastructure.Persistance.UnitOfWork.UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IProducer, ProducerOperations>();
            services.AddScoped<IRabbitMqService, RabbitMqService>();
            services.AddScoped<IMongoDbService, MongoDbService>();
            services.AddScoped<ICategoryCacheRepository, CategoryCacheRepository>();
        }
    }
}
