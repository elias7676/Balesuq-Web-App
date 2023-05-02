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
    public class ProductOrderDto
{
    [Key]
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid BuyerId { get; set; }

    // Navigation property
   // public Buyer Buyer { get; set; }


    // Navigation property
    //public Product Product { get; set; }
}
}