using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityManager.Authorize;
using IdentityManager.Data;
using IdentityManager.IRepositories;
using  Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using IdentityManager.Repositories;
using IdentityManager.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace IdentityManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
              services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddDefaultUI();
            services.AddTransient<IEmailSender, MailJetEmailSender>();
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequiredLength = 5;
                opt.Password.RequireLowercase = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                opt.Lockout.MaxFailedAccessAttempts = 5;
                
            });
            //services.ConfigureApplicationCookie(opt =>
            //{
            //    opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Accessdenied");
            //});
            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "2797980420437778";
                options.AppSecret = "abe6f05cc42cb58fef1e689b54a04011";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserAndAdmin", policy => policy.RequireRole("Admin").RequireRole("User"));
                options.AddPolicy("Admin_CreateAccess", policy => policy.RequireRole("Admin").RequireClaim("create", "True"));
                options.AddPolicy("Admin_Create_Edit_DeleteAccess", policy => policy.RequireRole("Admin").RequireClaim("create", "True")
                .RequireClaim("edit", "True")
                .RequireClaim("Delete", "True"));

                options.AddPolicy("Admin_Create_Edit_DeleteAccess_OR_SuperAdmin", policy => policy.RequireAssertion(context =>
                AuthorizeAdminWithClaimsOrSuperAdmin(context)));
                options.AddPolicy("OnlySuperAdminChecker", policy => policy.Requirements.Add(new OnlySuperAdminChecker()));
                options.AddPolicy("AdminWithMoreThan1000Days", policy => policy.Requirements.Add(new AdminWithMoreThan1000DaysRequirement(1000)));
                options.AddPolicy("FirstNameAuth", policy => policy.Requirements.Add(new FirstNameAuthRequirement("billy")));
            });
            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductOrderRepository, ProductOrderRepository>();
            services.AddScoped<ISubcityRepository, SubcityRepository>();
            services.AddScoped<IBuyerRequestRepository, BuyerRequestRepository>();
            services.AddScoped<IAuthorizationHandler, AdminWithOver1000DaysHandler>();
            services.AddScoped<IAuthorizationHandler, FirstNameAuthHandler>();
            services.AddScoped<INumberOfDaysForAccount, NumberOfDaysForAccount>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc()
           .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
           .AddNewtonsoftJson(options => {
             var resolver = options.SerializerSettings.ContractResolver;
             if (resolver != null)
               (resolver as DefaultContractResolver).NamingStrategy = null;
           });
  services.AddControllers();
  services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(Configuration.GetConnectionString("dev")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        private bool AuthorizeAdminWithClaimsOrSuperAdmin(AuthorizationHandlerContext context)
        {
            return (context.User.IsInRole("Admin") && context.User.HasClaim(c => c.Type == "Create" && c.Value == "True")
                        && context.User.HasClaim(c => c.Type == "Edit" && c.Value == "True")
                        && context.User.HasClaim(c => c.Type == "Delete" && c.Value == "True")
                    ) || context.User.IsInRole("SuperAdmin");
        }
    }
}
