﻿// <auto-generated />
using System;
using GradAppAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GradAppAPI.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("GradAppAPI.Core.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.InventoryRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Complete");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Details");

                    b.Property<int>("ResourceTypeId");

                    b.Property<int>("companyId");

                    b.Property<string>("userId");

                    b.HasKey("Id");

                    b.HasIndex("ResourceTypeId");

                    b.HasIndex("companyId");

                    b.HasIndex("userId");

                    b.ToTable("InventoryRequests");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ResourceTypeId");

                    b.Property<string>("StorageLocation")
                        .IsRequired();

                    b.Property<int>("TypeId");

                    b.Property<int?>("UseTicketId");

                    b.Property<int>("VehicleId");

                    b.Property<int>("companyId");

                    b.HasKey("Id");

                    b.HasIndex("ResourceTypeId");

                    b.HasIndex("UseTicketId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("companyId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.ResourceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ResourceTypes");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.UseTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Notes");

                    b.Property<int>("TISNumber");

                    b.Property<int>("TicketNumber");

                    b.Property<int>("companyId");

                    b.Property<string>("userId");

                    b.HasKey("Id");

                    b.HasIndex("companyId");

                    b.HasIndex("userId");

                    b.ToTable("UseTickets");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.UserVehicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("userId");

                    b.Property<int>("vehicleId");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.HasIndex("vehicleId");

                    b.ToTable("UserVehicles");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CheckedOut");

                    b.Property<string>("LicensePlate")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("AdminRole");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("JobDescription");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.InventoryRequest", b =>
                {
                    b.HasOne("GradAppAPI.Core.Models.ResourceType", "ResourceType")
                        .WithMany()
                        .HasForeignKey("ResourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradAppAPI.Core.Models.Company", "Company")
                        .WithMany("Requests")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradAppAPI.Core.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.Item", b =>
                {
                    b.HasOne("GradAppAPI.Core.Models.ResourceType", "ResourceType")
                        .WithMany("Resources")
                        .HasForeignKey("ResourceTypeId");

                    b.HasOne("GradAppAPI.Core.Models.UseTicket")
                        .WithMany("UsedItems")
                        .HasForeignKey("UseTicketId");

                    b.HasOne("GradAppAPI.Core.Models.Vehicle", "Vehicle")
                        .WithMany("Resources")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradAppAPI.Core.Models.Company", "Company")
                        .WithMany("Items")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.UseTicket", b =>
                {
                    b.HasOne("GradAppAPI.Core.Models.Company", "Company")
                        .WithMany("Tickets")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradAppAPI.Core.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("GradAppAPI.Core.Models.UserVehicles", b =>
                {
                    b.HasOne("GradAppAPI.Core.Models.User", "User")
                        .WithMany("VehicleAccess")
                        .HasForeignKey("userId");

                    b.HasOne("GradAppAPI.Core.Models.Vehicle", "Vehicle")
                        .WithMany("UserAccess")
                        .HasForeignKey("vehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
