using Quickorders.Domain;
using Quickorders.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Infrastructure.Context
{
    
    public class DataContext: IdentityDbContext<User>
    {
        
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

       
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Owner> Owner { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .Property(u => u.Id)
                .HasMaxLength(127);

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity
                .Property(u => u.LoginProvider)
                .HasMaxLength(127);

                entity
                .Property(u => u.Name)
                .HasMaxLength(127);


            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
           {
               entity
               .Property(u => u.LoginProvider)
               .HasMaxLength(127);

               entity
               .Property(u => u.ProviderKey)
               .HasMaxLength(127);

           });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity
                .Property(u => u.RoleId)
                .HasMaxLength(127);

            });


            builder.Entity<Restaurant>()
                .HasOne(restaurant => restaurant.Owner)
                .WithMany(owner => owner.Restaurants)
                .HasForeignKey(owner => owner.OwnerId);

            builder.Entity<Restaurant>()
                .HasMany(restaurant => restaurant.Menus)
                .WithOne(menu => menu.Restaurant)
                .HasForeignKey(menu => menu.RestaurantNit);

            builder.Entity<Menu>()
                .HasMany(menu => menu.Products)
                .WithOne(product => product.Menu)
                .HasForeignKey(product => product.MenuId);

            builder.Entity<User>()
                .HasMany(user => user.Orders)
                .WithOne(order => order.User)
                .HasForeignKey(order => order.UserId);

            builder.Entity<Order>()
                .HasMany(order => order.Products)
                .WithMany(product => product.Orders)
                .UsingEntity<OrderProduct>(

                    j => j
                    .HasOne(ordp => ordp.Product)
                    .WithMany(prod => prod.OrderProducts)
                    .HasForeignKey(ordp => ordp.ProductId),

                    j => j
                        .HasOne(ordp => ordp.Order)
                        .WithMany(order => order.OrderProducts)
                        .HasForeignKey(ordp => ordp.OrderId),

                    j =>
                    {
             
                        j.HasKey(ordp => new { ordp.ProductId, ordp.OrderId });
                    }
                );

          


        }


    }


}
