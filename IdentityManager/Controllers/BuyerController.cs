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
  [Route("api/buyer")]
  public class BuyerController :
    ControllerBase {
         private readonly IBuyerRepository repository;
    public BuyerController(
      IBuyerRepository repository)
      {
       this.repository = repository;
    }
    [HttpGet]
         public async Task<IEnumerable<Buyer>> GetItemsAsync()
        {
            var Buyers = await repository.GetItemsAsync();
            return Buyers;
        }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemAsync(Guid id)
        {
        var list = await repository.GetItemAsync(id);
        var item=  StatusCode(StatusCodes.Status200OK, list);
        return item;
          
        }
   [HttpPost()]
        public async Task<ActionResult<BuyerDto>> CreateItemAsync(CreateBuyerDto BuyerDto)
        {
                Buyer item = new()
            {
                // id = Guid.NewGuid(),
                Name = BuyerDto.Name,
                SubcityId = BuyerDto.SubcityId,
                Woreda = BuyerDto.Woreda,
                TinNo = BuyerDto.TinNo,
                LicenseImage = BuyerDto.LicenseImage,
                LicenseNo = BuyerDto.LicenseNo,
                Status = BuyerDto.Status,
                Phone = BuyerDto.Phone
                
            };
             await repository.CreateItemAsync(item);
             return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

[HttpPut("{id}")]
public async Task<IActionResult> UpdateItemAsync(Buyer entity, Guid Id)
{
    Buyer changed = await repository.GetItemAsync(Id);
    changed.Name = entity.Name;
    changed.SubcityId = entity.SubcityId;
    changed.Woreda = entity.Woreda;
    changed.TinNo = entity.TinNo;
    changed.LicenseNo = entity.LicenseNo;
    changed.LicenseImage = entity.LicenseImage;
    changed.Phone = entity.Phone;
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