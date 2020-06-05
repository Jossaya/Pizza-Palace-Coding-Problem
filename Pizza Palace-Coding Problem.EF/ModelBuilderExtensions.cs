using Microsoft.EntityFrameworkCore;
using Pizza_Palace_Coding_Problem.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Palace_Coding_Problem.EF
{
    /// <summary>
    /// For Seeding Initial Data
    /// </summary>
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaSize>().HasData(
                new PizzaSize { Id = 1, Name = "Small"},
                new PizzaSize { Id = 2, Name = "Medium" },
                new PizzaSize { Id = 3, Name = "Large" }
            );
            modelBuilder.Entity<Pizza>().HasData(
               new Pizza { Id=1, PizzaSizeId = 1, Price=12.00 },
               new Pizza { Id = 2, PizzaSizeId = 2, Price = 14.00 },
               new Pizza { Id = 3, PizzaSizeId = 3, Price = 16.00 }
           );
            modelBuilder.Entity<ToppingCategory>().HasData(
                new ToppingCategory { Id = 1, Name = "Basic Toppings" },
                new ToppingCategory { Id = 2, Name = "Deluxe Toppings" }
            );
            modelBuilder.Entity<Topping>().HasData(
                new Topping { Id = 1, PizzaSizeId = 1, ToppingCategoryId = 1, Price = 0.50, Name = "Cheese" },
                new Topping { Id = 2, PizzaSizeId = 2, ToppingCategoryId = 1, Price = 0.75, Name = "Cheese" },
                new Topping { Id = 3, PizzaSizeId = 3, ToppingCategoryId = 1, Price = 1.00, Name = "Cheese" },

                new Topping { Id = 4, PizzaSizeId = 1, ToppingCategoryId = 1, Price = 0.50, Name = "Pepperoni" },
                new Topping { Id = 5, PizzaSizeId = 2, ToppingCategoryId = 1, Price = 0.75, Name = "Pepperoni" },
                new Topping { Id = 6, PizzaSizeId = 3, ToppingCategoryId = 1, Price = 1.00, Name = "Pepperoni" },

                new Topping { Id = 7, PizzaSizeId = 1, ToppingCategoryId = 1, Price = 0.50, Name = "Ham" },
                new Topping { Id = 8, PizzaSizeId = 2, ToppingCategoryId = 1, Price = 0.75, Name = "Ham" },
                new Topping { Id = 9, PizzaSizeId = 3, ToppingCategoryId = 1, Price = 1.00, Name = "Ham" },

                new Topping { Id = 10, PizzaSizeId = 1, ToppingCategoryId = 1, Price = 0.50, Name = "Pineapple" },
                new Topping { Id = 11, PizzaSizeId = 2, ToppingCategoryId = 1, Price = 0.75, Name = "Pineapple" },
                new Topping { Id = 12, PizzaSizeId = 3, ToppingCategoryId = 1, Price = 1.00, Name = "Pineapple" },

                new Topping { Id = 13, PizzaSizeId = 1, ToppingCategoryId = 2, Price = 2.00, Name = "Sausage" },
                new Topping { Id = 14, PizzaSizeId = 2, ToppingCategoryId = 2, Price = 3.00, Name = "Sausage" },
                new Topping { Id = 15, PizzaSizeId = 3, ToppingCategoryId = 2, Price = 4.00, Name = "Sausage" },

                new Topping { Id = 16, PizzaSizeId = 1, ToppingCategoryId = 2, Price = 2.00, Name = "Feta Cheese" },
                new Topping { Id = 17, PizzaSizeId = 2, ToppingCategoryId = 2, Price = 3.00, Name = "Feta Cheese" },
                new Topping { Id = 18, PizzaSizeId = 3, ToppingCategoryId = 2, Price = 4.00, Name = "Feta Cheese" },

                new Topping { Id = 19, PizzaSizeId = 1, ToppingCategoryId = 2, Price = 2.00, Name = "Tomatoes" },
                new Topping { Id = 20, PizzaSizeId = 2, ToppingCategoryId = 2, Price = 3.00, Name = "Tomatoes" },
                new Topping { Id = 21, PizzaSizeId = 3, ToppingCategoryId = 2, Price = 4.00, Name = "Tomatoes" },

                new Topping { Id = 22, PizzaSizeId = 1, ToppingCategoryId = 2, Price = 2.00, Name = "Olives" },
                new Topping { Id = 23, PizzaSizeId = 2, ToppingCategoryId = 2, Price = 3.00, Name = "Olives" },
                new Topping { Id = 24, PizzaSizeId = 3, ToppingCategoryId = 2, Price = 4.00, Name = "Olives" }
            );
        }
    }
}
