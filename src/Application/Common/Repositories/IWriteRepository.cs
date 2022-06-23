﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> models);
        Task<bool> UpdateAsync(T entity);
        bool Update(T model);
        Task<bool> RemoveAsync(T model);
        Task<bool> RemoveAsync(string id);
        bool Remove(T model);
        bool RemoveRange(List<T> models);
        Task<int> SaveAsync();
    }
}
