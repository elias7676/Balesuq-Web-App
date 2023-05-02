using IdentityManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Product> Product {get; set;}
        public DbSet<Buyer> Buyer {get; set;}
        public DbSet<Category> Category {get; set;}
        public DbSet<Subcity> Subcity {get; set;}
        public DbSet<ProductOrder> ProductOrder {get; set;}
        public DbSet<BuyerRequest> BuyerRequest {get; set;}


    }
}
