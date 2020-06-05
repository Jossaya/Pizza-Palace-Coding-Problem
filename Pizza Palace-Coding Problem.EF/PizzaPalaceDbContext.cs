using Microsoft.EntityFrameworkCore;
using Pizza_Palace_Coding_Problem.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza_Palace_Coding_Problem.EF
{
    /// <summary>
    /// For Defining the Repository pattern of our App
    /// </summary>
    public class PizzaPalaceDbContext : DbContext
    {
        public PizzaPalaceDbContext(DbContextOptions<PizzaPalaceDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Seed();
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PizzaSize> PizzaSizes { get; set; }
        public DbSet<ToppingCategory> ToppingCategories { get; set; }
        public DbSet<Topping> Toppings { get; set; }

    }
}
