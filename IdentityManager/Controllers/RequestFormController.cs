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
    public class RequestFormController : Controller
    {
         public IActionResult Index()
        {
            return View();
        }
        
    }
}
