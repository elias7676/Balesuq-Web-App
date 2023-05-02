using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityManager.Data;
using IdentityManager.Dto;
using IdentityManager.IRepositories;
using IdentityManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager.Repositories

{
    
    public class ProductOrderRepository : IProductOrderRepository
    {
         private ApplicationDbContext _DbContext;
          List<ProductOrder> list = new List<ProductOrder>();

        public ProductOrderRepository ( ApplicationDbContext context): base()
        {
             _DbContext = context;
        }
        public async Task<IEnumerable<ProductOrder>> GetItemsAsync()
        {
            return await _DbContext.ProductOrder
                                    .Include(po => po.Product)
                                        .ThenInclude(p => p.Category)
                                    .Include(po => po.Buyer)
                                        .ThenInclude(b => b.Subcity)
                                    .ToListAsync();

           // return productOrders.Select(po => po.AsDto());
        }


        public async ValueTask<ProductOrder> GetItemAsync(Guid id)
        {
            return await _DbContext.ProductOrder
                                    .Include(po => po.Buyer)
                                        .ThenInclude(b => b.Subcity)
                                    .Include(po => po.Product)
                                        .ThenInclude(p => p.Category)
                                    .FirstOrDefaultAsync(po => po.Id == id);
        }


        public async Task CreateItemAsync(ProductOrder productOrder)
        {
         await _DbContext.ProductOrder.AddAsync(productOrder);
         await  _DbContext.SaveChangesAsync();
        }
        public async Task UpdateItemAsync(ProductOrder productOrder)
        {
            _DbContext.ChangeTracker.Clear();
             _DbContext.ProductOrder.Update(productOrder);
       await _DbContext.SaveChangesAsync();
            
        }
        public async Task DeleteItemAsync(Guid id)
        {

            var entity = await _DbContext.ProductOrder.FindAsync(id);
             _DbContext.ProductOrder.Remove(entity);
             await _DbContext.SaveChangesAsync();
        }

       
    }
}