using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Dto
{

    public class CreateBuyerRequestDto
{

    [Required]
    public Guid BuyerId { get; set; }
    [Required]
    public int Status { get; set; }

    // Navigation property
   // public Buyer Buyer { get; set; }
}
}