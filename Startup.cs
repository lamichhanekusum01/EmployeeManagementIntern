using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Controllers;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace EmployeeManagement
{
    public class Startup
    {
        private IConfigurationRoot _config;
        public Startup(IWebHostEnvironment env)
        {
            var ConfigBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                       .AddJsonFile("appsettings.json");
            _config = ConfigBuilder.Build();
        }
        public IConfiguration Configuration { get; }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            IdentityResult roleResult ,roleResults;
            //Adding Addmin Role  
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
            ApplicationUser user = await UserManager.FindByEmailAsync("admin@gmail.com");
            var User = new ApplicationUser();
            await UserManager.AddToRoleAsync(user, "Admin");
            //await UserManager.AddToRoleAsync(user, "Employee");


            var roleCheckEmp = await RoleManager.RoleExistsAsync("Employee");
            if (!roleCheckEmp)
            {
               
                roleResults = await RoleManager.CreateAsync(new IdentityRole("Employee"));
            }
            //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
           
        }
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSingleton(_config);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<EmployeeManagementDbContext>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeProvider, EmployeeProvider>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            
            services.AddScoped<IApplicationUserProvider,ApplicationUserProvider>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<IHolidayProvider,HolidayProvider>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<ILeaveProvider, LeaveProvider>();
            services.AddScoped<IAttendenceRepository, AttendenceRepository>();
            services.AddScoped<IAttendenceProvider, AttendenceProvider>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ,IServiceProvider services)
        {
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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateUserRoles(services).Wait();  
        }
    }
}
