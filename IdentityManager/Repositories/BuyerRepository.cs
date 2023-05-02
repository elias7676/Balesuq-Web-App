using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Data;
using IdentityManager.IRepositories;
using IdentityManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager.Repositories

{
    
    public class BuyerRepository : IBuyerRepository
    {
         private ApplicationDbContext _DbContext;
          List<Buyer> list = new List<Buyer>();

        public BuyerRepository ( ApplicationDbContext context): base()
        {
             _DbContext = context;
        }
        public async Task<IEnumerable<Buyer>> GetItemsAsync()
        {
          return await _DbContext.Buyer
                    .Include(b => b.Subcity)
                    .ToListAsync();
        }
        public async ValueTask<Buyer> GetItemAsync(Guid id)
        {
            return await _DbContext.Buyer
                .Include(b => b.Subcity)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task CreateItemAsync(Buyer Buyer)
        {
         await _DbContext.Buyer.AddAsync(Buyer);
         await  _DbContext.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(Buyer Buyer)
        {
            _DbContext.ChangeTracker.Clear();
             _DbContext.Buyer.Update(Buyer);
       await _DbContext.SaveChangesAsync();
            
        }
        public async Task DeleteItemAsync(Guid id)
        {

            var entity = await _DbContext.Buyer.FindAsync(id);
             _DbContext.Buyer.Remove(entity);
             await _DbContext.SaveChangesAsync();
        }

       
    }
}