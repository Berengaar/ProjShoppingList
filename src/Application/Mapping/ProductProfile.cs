﻿using Application.Common.Models;
using Application.CQS.ProductR.Commands.AddProductToShopList;
using Application.CQS.ProductR.Commands.RemoveProduct;
using Application.CQS.ProductR.Commands.UpdateProduct;
using Application.CQS.ProductR.Queries;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            //Command
            CreateMap<SoftRemoveProductCommandRequest,Product>().ReverseMap(); 
            CreateMap<UpdateProductCommandRequest, Product>().ReverseMap();
            CreateMap<AddProductToShopListCommandRequest, Product>().ReverseMap();

            //Query
            CreateMap<Product,GetAllProductsInShopListQueryResponse>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();

        }
    }
}
