using AutoMapper.Configuration;
using BetCommerce.Entities.AuthenticationEntities;
using BetCommerce.Entities.CustomerEntities;
using BetCommerce.Entities.Orders;
using BetCommerce.Entities.ProductEntities;
using BetCommerce.Entities.ProductsEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<OrderDetail> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public void SetCommandTimeOut(int timeOut)
        {
            Database.SetCommandTimeout(timeOut);
        }

        //
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
            SetCommandTimeOut(1000);
        }
    }
}
