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
  [Route("api/Subcity")]
  public class SubcityController :
    ControllerBase {
         private readonly ISubcityRepository repository;
    public SubcityController(
      ISubcityRepository repository)
      {
       this.repository = repository;
    }
    [HttpGet]
         public async Task<IEnumerable<Subcity>> GetItemsAsync()
        {
            var Subcitys = (await repository.GetItemsAsync())
                        .Select(Subcity => Subcity.AsDto());
            return Subcitys;
        }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemAsync(Guid id)
        {
        var list = await repository.GetItemAsync(id);
        var item=  StatusCode(StatusCodes.Status200OK, list);
        return item;
          
        }
   [HttpPost()]
        public async Task<ActionResult<SubcityDto>> CreateItemAsync(CreateSubcityDto SubcityDto)
        {
                Subcity item = new()
            {
                // id = Guid.NewGuid(),

                Name = SubcityDto.Name
                
            };
             await repository.CreateItemAsync(item);
             return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

[HttpPut("{id}")]
public async Task<IActionResult> UpdateItemAsync(Subcity entity, Guid Id)
{
    Subcity changed = await repository.GetItemAsync(Id);
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