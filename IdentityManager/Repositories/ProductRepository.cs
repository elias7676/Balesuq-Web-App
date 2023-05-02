using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityManager.Data;
using IdentityManager.IRepositories;
using IdentityManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager.Repositories

{
    
    public class ProductRepository : IProductRepository
    {
         private ApplicationDbContext _DbContext;
          List<Product> list = new List<Product>();

        public ProductRepository ( ApplicationDbContext context): base()
        {
             _DbContext = context;
        }
        public async Task<IEnumerable<Product>> GetItemsAsync()
        {
          return await _DbContext.Product
                        .Include(p => p.Category)
                      .ToListAsync();
        }
        public async ValueTask<Product> GetItemAsync(Guid id)
        {
          return await _DbContext.Product
                                    .Include(p => p.Category)
                                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateItemAsync(Product product)
        {
         await _DbContext.Product.AddAsync(product);
         await  _DbContext.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(Product product)
        {
            _DbContext.ChangeTracker.Clear();
             _DbContext.Product.Update(product);
       await _DbContext.SaveChangesAsync();
            
        }
        public async Task DeleteItemAsync(Guid id)
        {

            var entity = await _DbContext.Product.FindAsync(id);
             _DbContext.Product.Remove(entity);
             await _DbContext.SaveChangesAsync();
        }

       
    }
}