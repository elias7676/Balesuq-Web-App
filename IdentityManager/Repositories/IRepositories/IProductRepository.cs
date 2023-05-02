using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Models;

namespace IdentityManager.IRepositories
{
    public interface IProductRepository
    {
        ValueTask<Product> GetItemAsync(Guid rowguid);
        Task<IEnumerable<Product>> GetItemsAsync();
        Task CreateItemAsync(Product product);
        Task UpdateItemAsync(Product product);
        Task DeleteItemAsync(Guid rowguid);
    }
    }