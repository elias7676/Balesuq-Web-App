using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Models
{
public class ProductOrder
{
    [Key]
    public Guid Id { get; set; }
    
    [ForeignKey("product")]
    public Guid ProductId { get; set; }

    public int Amount { get; set; }
    public DateTime CreatedDate { get; set; }

    [ForeignKey("buyer")]
    public Guid BuyerId { get; set; }

    // Navigation properties
    public Buyer Buyer { get; set; }
    public Product Product { get; set; }
}

}