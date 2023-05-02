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

    public class ProductDto
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public string Unit { get; set; }
    public string Brand { get; set; }
    public string Image { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Status { get; set; }

    // Navigation property
    //public Category Category { get; set; }
}
}