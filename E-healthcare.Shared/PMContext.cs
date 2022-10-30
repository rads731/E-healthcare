using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ProjectManagement.Shared
{
    public class PMContext : DbContext
    {
        public PMContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<BaseEntity> BaseEntity { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Users> User { get; set; }
  
    }
}
