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

    public class CreateCategoryDto
{
    [Required]
    public string Name { get; set; }

    // Navigation property
    //public ICollection<Product> Products { get; set; }
}
}