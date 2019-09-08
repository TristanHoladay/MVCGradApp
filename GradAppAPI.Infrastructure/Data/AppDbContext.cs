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
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Item> Items { get; set; }

        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ../GradAppAPI.Infrastructure/inventory_tracker.db");
        }

    }
}
