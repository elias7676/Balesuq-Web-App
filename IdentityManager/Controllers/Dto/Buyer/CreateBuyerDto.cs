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

    public class CreateBuyerDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public Guid SubcityId { get; set; }
    [Required]
    public string Woreda { get; set; }
    [Required]
    public string TinNo { get; set; }
    [Required]
    public string LicenseNo { get; set; }
    [Required]
    public string LicenseImage { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public int Status { get; set; }

    // Navigation property
    //public Subcity Subcity { get; set; }
}
}