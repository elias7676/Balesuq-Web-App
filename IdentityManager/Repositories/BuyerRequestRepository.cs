using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Data;
using IdentityManager.IRepositories;
using IdentityManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager.Repositories

{
    
    public class BuyerRequestRepository : IBuyerRequestRepository
    {
         private ApplicationDbContext _DbContext;
          List<BuyerRequest> list = new List<BuyerRequest>();

        public BuyerRequestRepository ( ApplicationDbContext context): base()
        {
             _DbContext = context;
        }
        public async Task<IEnumerable<BuyerRequest>> GetItemsAsync()
        {
          return await _DbContext.BuyerRequest
                                .Include(br => br.Buyer)
                                    .ThenInclude(b => b.Subcity)
                                .ToListAsync();
        }
        public async ValueTask<BuyerRequest> GetItemAsync(Guid id)
        {
            return await _DbContext.BuyerRequest
                .Include(br => br.Buyer)
                     .ThenInclude(b => b.Subcity)
                .FirstOrDefaultAsync(br => br.Id == id);
        }
        public async Task CreateItemAsync(BuyerRequest BuyerRequest)
        {
         await _DbContext.BuyerRequest.AddAsync(BuyerRequest);
         await  _DbContext.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(BuyerRequest BuyerRequest)
        {
            _DbContext.ChangeTracker.Clear();
             _DbContext.BuyerRequest.Update(BuyerRequest);
       await _DbContext.SaveChangesAsync();
            
        }
        public async Task DeleteItemAsync(Guid id)
        {

            var entity = await _DbContext.BuyerRequest.FindAsync(id);
             _DbContext.BuyerRequest.Remove(entity);
             await _DbContext.SaveChangesAsync();
        }

       
    }
}