using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using IdentityManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IdentityManager.Data;
using Mailjet.Client.Resources;
using IdentityManager.IRepositories;

namespace IdentityManager.Controllers
{
    public class ProductViewController : Controller
    {
         public async Task<IActionResult> Index()
        {
            var productList = await repository.GetItemsAsync();
            return View(productList);
        }
         private readonly IProductRepository repository;
    public ProductViewController(
      IProductRepository repository)
      {
       this.repository = repository;
    }
        ApplicationDbContext _DbContext;
        private const string ENTITY_NAME = "Product";
        private readonly RoleManager<IdentityRole> _roleManager;
        IActionResult ret = null;

        [HttpGet]
        public async Task<IActionResult> ProductAsync()
            {
            var productList = await repository.GetItemsAsync();
            //Console.WriteLine(productList);
               // ProductViewModel productViewModel = new ProductViewModel();
            return View(productList);
            
        }
    }
}
