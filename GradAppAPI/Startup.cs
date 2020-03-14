using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GradAppAPI.Core.Services;
using GradAppAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using GradAppAPI.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GradAppAPI
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
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHttpContextAccessor();


            //services.AddDbContext<AppDbContext>();

            // Use SQL Database if in Azure, otherwise, use SQLite
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("TrackITDbConnection")));
            else
                services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite("Data Source=../GradAppAPI.Infrastructure/inventoryTracker.db"));

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();

            // JWT support
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });


            //Identity User
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            // DbInititializer service
            //services.AddScoped<DbInitializer>();

            //Repositories and Services
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IResourceTypeRepository, ResourceTypeRepository>();
            services.AddScoped<IResourceTypeService, ResourceTypeService>();

            services.AddScoped<IUserVehiclesRepository, UserVehiclesRepository>();
            services.AddScoped<IUserVehiclesService, UserVehiclesService>();

            services.AddScoped<IUseTicketRepository, UseTicketsRepository>();
            services.AddScoped<IUseTicketService, UseTicketService>();

            services.AddScoped<IInventoryRequestRepository, InventoryRequestRepository>();
            services.AddScoped<IInventoryRequestService, InventoryRequestService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<PasswordHasher<User>>();

            services.AddScoped<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            //dbInitializer.Initialize();
        }
    }
}
