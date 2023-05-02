using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Data;
using IdentityManager.IRepositories;
using IdentityManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager.Repositories

{
    
    public class SubcityRepository : ISubcityRepository
    {
         private ApplicationDbContext _DbContext;
          List<Subcity> list = new List<Subcity>();

        public SubcityRepository ( ApplicationDbContext context): base()
        {
             _DbContext = context;
        }
        public async Task<IEnumerable<Subcity>> GetItemsAsync()
        {
          return await _DbContext.Subcity.ToListAsync();
        }
        public async ValueTask<Subcity> GetItemAsync(Guid id)
        {
           return await _DbContext.Subcity.FindAsync(id);
        }
        public async Task CreateItemAsync(Subcity Subcity)
        {
         await _DbContext.Subcity.AddAsync(Subcity);
         await  _DbContext.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(Subcity Subcity)
        {
            _DbContext.ChangeTracker.Clear();
             _DbContext.Subcity.Update(Subcity);
       await _DbContext.SaveChangesAsync();
            
        }
        public async Task DeleteItemAsync(Guid id)
        {

            var entity = await _DbContext.Subcity.FindAsync(id);
             _DbContext.Subcity.Remove(entity);
             await _DbContext.SaveChangesAsync();
        }


    }
}