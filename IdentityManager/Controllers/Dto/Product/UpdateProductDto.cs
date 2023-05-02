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

    public class UpdateProductDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
    [Required]
    public string Unit { get; set; }
    [Required]
    public string Brand { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public int Status { get; set; }

    // Navigation property
    //public Category Category { get; set; }
}
}