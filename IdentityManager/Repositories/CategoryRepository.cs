using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Data;
using IdentityManager.IRepositories;
using IdentityManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager.Repositories

{
    
    public class CategoryRepository : ICategoryRepository
    {
         private ApplicationDbContext _DbContext;
          List<Category> list = new List<Category>();

        public CategoryRepository ( ApplicationDbContext context): base()
        {
             _DbContext = context;
        }
        public async Task<IEnumerable<Category>> GetItemsAsync()
        {
          return await _DbContext.Category.ToListAsync();
        }
        public async ValueTask<Category> GetItemAsync(Guid id)
        {
            return await _DbContext.Category
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateItemAsync(Category Category)
        {
         await _DbContext.Category.AddAsync(Category);
         await  _DbContext.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(Category Category)
        {
            _DbContext.ChangeTracker.Clear();
             _DbContext.Category.Update(Category);
       await _DbContext.SaveChangesAsync();
            
        }
        public async Task DeleteItemAsync(Guid id)
        {

            var entity = await _DbContext.Category.FindAsync(id);
             _DbContext.Category.Remove(entity);
             await _DbContext.SaveChangesAsync();
        }

       
    }
}