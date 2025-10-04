using AssetManager.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Data.Infrastructure
{
    public class AppDbContext : DbContext
    {
        // Constructor to pass options from DI (Dependency Injection)
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Tables
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetAssignment> AssetAssignments { get; set; }

        // Configure relationships & seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee Config
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Department).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.Designation).HasMaxLength(100);
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                // Seed Data
                entity.HasData(
                    new Employee { EmployeeId = 1, FullName = "John Doe", Department = "IT", Email = "john.doe@example.com", PhoneNumber = "1234567890", Designation = "Developer", IsActive = true },
                    new Employee { EmployeeId = 2, FullName = "Jane Smith", Department = "HR", Email = "jane.smith@example.com", PhoneNumber = "9876543210", Designation = "HR Manager", IsActive = true }
                );
            });

            // Asset Config
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.HasKey(a => a.AssetId);
                entity.Property(a => a.AssetName).IsRequired().HasMaxLength(200);
                entity.Property(a => a.AssetType).HasMaxLength(100);
                entity.Property(a => a.MakeModel).HasMaxLength(150);
                entity.Property(a => a.SerialNumber).HasMaxLength(100);
                entity.Property(a => a.Condition)
              .HasConversion<string>()
              .HasMaxLength(50)
              .IsRequired();

                entity.Property(a => a.Status)
                      .HasConversion<string>()
                      .HasMaxLength(50)
                      .IsRequired();
                entity.Property(a => a.IsSpare).HasDefaultValue(false);

                // Seed Data
                entity.HasData(
                    new Asset { AssetId = 1, AssetName = "Dell Laptop", AssetType = "Electronics", MakeModel = "Dell Latitude 5420", SerialNumber = "DL12345", PurchaseDate = new DateTime(2024, 01, 01), WarrantyExpiryDate = new DateTime(2027, 01, 01), Condition = AssetCondition.New, Status = AssetStatus.Available, IsSpare = false, Specifications = "i7, 16GB RAM, 512GB SSD" },
                    new Asset { AssetId = 2, AssetName = "HP Printer", AssetType = "Electronics", MakeModel = "HP LaserJet Pro", SerialNumber = "HP98765", PurchaseDate = new DateTime(2023, 05, 15), WarrantyExpiryDate = new DateTime(2026, 05, 15), Condition = AssetCondition.Good, Status = AssetStatus.Available, IsSpare = true, Specifications = "Laser, Duplex Printing" }
                );
            });

            // AssetAssignment Config
            modelBuilder.Entity<AssetAssignment>(entity =>
            {
                entity.HasKey(aa => aa.AssetAssignmentId);
                entity.Property(aa => aa.AssignedDate).IsRequired();

                entity.HasOne(aa => aa.Asset)
                      .WithMany(a => a.AssetAssignments)
                      .HasForeignKey(aa => aa.AssetId);

                entity.HasOne(aa => aa.Employee)
                      .WithMany(e => e.AssetAssignments)
                      .HasForeignKey(aa => aa.EmployeeId);

                // Seed Data
                entity.HasData(
                    new AssetAssignment { AssetAssignmentId = 1, AssetId = 1, EmployeeId = 1, AssignedDate = new DateTime(2024, 02, 01), Notes = "Primary laptop" }
                );
            });
        }

    }
}
