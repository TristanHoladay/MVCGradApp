using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {

        public DbSet<Company> Companies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<UserVehicles> UserVehicles { get; set; }
        public DbSet<UseTicket> UseTickets { get; set; }
        public DbSet<InventoryRequest> InventoryRequests { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=../GradAppAPI.Infrastructure/inventoryTracker.db");
        }
    }
}
