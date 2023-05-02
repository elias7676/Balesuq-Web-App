using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Models;

namespace IdentityManager.IRepositories
{
    public interface IBuyerRequestRepository
    {
        ValueTask<BuyerRequest> GetItemAsync(Guid rowguid);
        Task<IEnumerable<BuyerRequest>> GetItemsAsync();
        Task CreateItemAsync(BuyerRequest request);
        Task UpdateItemAsync(BuyerRequest request);
        Task DeleteItemAsync(Guid rowguid);
    }
    }