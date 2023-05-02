using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Models;

namespace IdentityManager.IRepositories
{
    public interface ICategoryRepository
    {
        ValueTask<Category> GetItemAsync(Guid rowguid);
        Task<IEnumerable<Category>> GetItemsAsync();
        Task CreateItemAsync(Category category);
        Task UpdateItemAsync(Category category);
        Task DeleteItemAsync(Guid rowguid);
    }
    }