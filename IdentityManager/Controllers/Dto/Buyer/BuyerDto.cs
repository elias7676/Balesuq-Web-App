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

    public class BuyerDto
{
    [Key]
    public Guid Id { get; set; }
 
    public string Name { get; set; }

    public Guid SubcityId { get; set; }

    public string Woreda { get; set; }
 
    public string TinNo { get; set; }
    public string LicenseNo { get; set; }
    public string LicenseImage { get; set; }
    public string Phone { get; set; }
    public int Status { get; set; }

    // Navigation property
    //public Subcity Subcity { get; set; }
}
}