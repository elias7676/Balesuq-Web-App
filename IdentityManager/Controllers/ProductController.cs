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
  [Route("api/product")]
  public class ProductController :
    Controller {
         private readonly IProductRepository repository;
    public ProductController(
      IProductRepository repository)
      {
       this.repository = repository;
    }
    public async Task<IActionResult> Index()
        {
           var products = await repository.GetItemsAsync();
            return View(products);
        }
    [HttpGet]
         public async Task<IEnumerable<Product>> GetItemsAsync()
        {
            var products = await repository.GetItemsAsync();
                        
            return products;
        }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemAsync(Guid id)
        {
        var list = await repository.GetItemAsync(id);
        var item=  StatusCode(StatusCodes.Status200OK, list);
        return item;
          
        }
   [HttpPost()]
        public async Task<ActionResult<ProductDto>> CreateItemAsync(CreateProductDto productDto)
        {
                Product item = new()
            {
                // id = Guid.NewGuid(),
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                Brand = productDto.Brand,
                Unit = productDto.Unit,
                Image = productDto.Image,
                Status = productDto.Status,
                CreatedDate = DateTime.Now
                
            };
             await repository.CreateItemAsync(item);
             return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

[HttpPut("{id}")]
public async Task<IActionResult> UpdateItemAsync(Product entity, Guid Id)
{
    Product changed = await repository.GetItemAsync(Id);
    changed.Name = entity.Name;
    changed.Price = entity.Price;
    changed.CategoryId = entity.CategoryId;
    changed.Brand = entity.Brand;
    changed.Unit = entity.Unit;
    changed.Image = entity.Image;
    changed.CreatedDate = entity.CreatedDate;
    changed.Status = entity.Status;

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