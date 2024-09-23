﻿using Microsoft.EntityFrameworkCore;
using MassTransit;
using Restaurant.Infrastructure.Models;

namespace Restaurant.Infrastructure
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AddressDbEntity> Addresses { get; set; }

        public DbSet<MenuDbEntity> Menus { get; set; }

        public DbSet<MenuItemAvailabilityDbEntity> MenuItemAvailabilities { get; set; }

        public DbSet<MenuItemCategoryDbEntity> MenuItemCategories { get; set; }

        public DbSet<MenuItemDbEntity> MenuItems { get; set; }

        public DbSet<RestaurantDbEntity> Restaurants { get; set; }

        public DbSet<WorkingScheduleDbEntity> WorkingSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureMarker).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();

            modelBuilder.Entity<MenuItemDbEntity>(x => x.Property(y => y.Price).HasPrecision(2));
        }
    }
}
