using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Models;

namespace IdentityManager.IRepositories
{
    public interface ISubcityRepository
    {
        ValueTask<Subcity> GetItemAsync(Guid rowguid);
        Task<IEnumerable<Subcity>> GetItemsAsync();
        Task CreateItemAsync(Subcity subcity);
        Task UpdateItemAsync(Subcity subcity);
        Task DeleteItemAsync(Guid rowguid);
    }
    }