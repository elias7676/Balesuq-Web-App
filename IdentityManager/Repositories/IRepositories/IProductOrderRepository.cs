using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Models;

namespace IdentityManager.IRepositories
{
    public interface IProductOrderRepository
    {
        ValueTask<ProductOrder> GetItemAsync(Guid rowguid);
        Task<IEnumerable<ProductOrder>> GetItemsAsync();
        Task CreateItemAsync(ProductOrder order);
        Task UpdateItemAsync(ProductOrder order);
        Task DeleteItemAsync(Guid rowguid);
    }
    }