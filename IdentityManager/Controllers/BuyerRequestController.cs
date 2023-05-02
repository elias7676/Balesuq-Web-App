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
  [Route("api/buyerRequest")]
  public class BuyerRequestController :
    ControllerBase {
         private readonly IBuyerRequestRepository repository;
    public BuyerRequestController(
      IBuyerRequestRepository repository)
      {
       this.repository = repository;
    }
    [HttpGet]
         public async Task<IEnumerable<BuyerRequest>> GetItemsAsync()
        {
            var BuyerRequests = await repository.GetItemsAsync();
                       
            return BuyerRequests;
        }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemAsync(Guid id)
        {
        var list = await repository.GetItemAsync(id);
        var item=  StatusCode(StatusCodes.Status200OK, list);
        return item;
          
        }
   [HttpPost()]
        public async Task<ActionResult<BuyerRequestDto>> CreateItemAsync(CreateBuyerRequestDto BuyerRequestDto)
        {
                BuyerRequest item = new()
            {
                // id = Guid.NewGuid(),

                Status = BuyerRequestDto.Status,
                BuyerId = BuyerRequestDto.BuyerId
                
            };
             await repository.CreateItemAsync(item);
             return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

[HttpPut("{id}")]
public async Task<IActionResult> UpdateItemAsync(BuyerRequest entity, Guid Id)
{
    BuyerRequest changed = await repository.GetItemAsync(Id);
    changed.BuyerId = entity.BuyerId;
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