using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Models;

namespace IdentityManager.IRepositories
{
    public interface IBuyerRepository
    {
        ValueTask<Buyer> GetItemAsync(Guid rowguid);
        Task<IEnumerable<Buyer>> GetItemsAsync();
        Task CreateItemAsync(Buyer buyer);
        Task UpdateItemAsync(Buyer buyer);
        Task DeleteItemAsync(Guid rowguid);
    }
    }