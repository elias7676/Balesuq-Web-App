using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityManager.Dto;
using IdentityManager.Models;
using IdentityManager;
using IdentityManager.IRepositories;

namespace IdentityManager.Controllers {
  [ApiController]
  [Route("api/productorder")]
  public class ProductOrderController :
    ControllerBase {
         private readonly IProductOrderRepository repository;
    public ProductOrderController(
      IProductOrderRepository repository)
      {
       this.repository = repository;
    }
    [HttpGet]
         public async Task<IEnumerable<ProductOrder>> GetItemsAsync()
        {
            var productOrders =await repository.GetItemsAsync();
                        
            return  productOrders;
        }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemAsync(Guid id)
        {
        var list = await repository.GetItemAsync(id);
        var item=  StatusCode(StatusCodes.Status200OK, list);
        return item;
          
        }
   [HttpPost()]
        public async Task<ActionResult<ProductOrderDto>> CreateItemAsync(CreateProductOrderDto productOrderDto)
        {
                ProductOrder item = new()
            {
                // id = Guid.NewGuid(),
                ProductId = productOrderDto.ProductId,
                BuyerId = productOrderDto.BuyerId,
                Amount = productOrderDto.Amount,
                CreatedDate = productOrderDto.CreatedDate
                
            };
             await repository.CreateItemAsync(item);
             return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

[HttpPut("{id}")]
public async Task<IActionResult> UpdateItemAsync(ProductOrder entity, Guid Id)
{
    ProductOrder changed = await repository.GetItemAsync(Id);
    changed.ProductId = entity.ProductId;
    changed.BuyerId = entity.BuyerId;
    changed.Amount = entity.Amount;
    changed.CreatedDate = entity.CreatedDate;

    await repository.UpdateItemAsync(changed);

    return AcceptedAtAction(nameof(GetItemAsync), new { id = changed.Id }, changed.AsDto());
}


      [HttpDelete("{id}")]
      public async Task<ActionResult> DeleteItemAsync(Guid id){
        var existingItem = await repository.GetItemAsync(id);
        await repository.DeleteItemAsync(id);

      return NoContent();
      }

    }

}