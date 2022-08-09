using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EntityLib.ProductsManagment;
using EntityLib.UserManagment;
using EntityLib.ImactStoriesManagment;
using EntityLib.OrdersManagment;

namespace EntityLib
{
    public class ApplicationDB : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<ImpactStory> ImpactStoies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>().ToTable("CartItems");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=.;Database=BrightLightDB2;Trusted_Connection=True;MultipleActiveResultSets=True");
        }


    }
}
