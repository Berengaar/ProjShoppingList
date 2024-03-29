﻿using Application.Common.Models;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEditableEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T> GetWhereAsync(Expression<Func<T, bool>> condition);
        Task<List<T>> GetWithCacheAsync(string cacheKey);

        //Pagination
    }
}
