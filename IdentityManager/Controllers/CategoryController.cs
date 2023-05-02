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
  [Route("api/Category")]
  public class CategoryController :
    ControllerBase {
         private readonly ICategoryRepository repository;
    public CategoryController(
      ICategoryRepository repository)
      {
       this.repository = repository;
    }
    [HttpGet]
         public async Task<IEnumerable<Category>> GetItemsAsync()
        {
            var Categorys = (await repository.GetItemsAsync())
                        .Select(Category => Category.AsDto());
            return Categorys;
        }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemAsync(Guid id)
        {
        var list = await repository.GetItemAsync(id);
        var item=  StatusCode(StatusCodes.Status200OK, list);
        return item;
          
        }
   [HttpPost()]
        public async Task<ActionResult<CategoryDto>> CreateItemAsync(CreateCategoryDto CategoryDto)
        {
                Category item = new()
            {
                // id = Guid.NewGuid(),

                Name = CategoryDto.Name
                
            };
             await repository.CreateItemAsync(item);
             return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

[HttpPut("{id}")]
public async Task<IActionResult> UpdateItemAsync(Category entity, Guid Id)
{
    Category changed = await repository.GetItemAsync(Id);
    changed.Name = entity.Name;

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