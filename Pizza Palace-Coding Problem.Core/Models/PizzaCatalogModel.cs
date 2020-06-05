using Pizza_Palace_Coding_Problem.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Palace_Coding_Problem.Core.Models
{
    /// <summary>
    /// Acts as a transformation object for PizzaCatalog Entity that stores Pizza Item Prices
    /// </summary>
    public class PizzaCatalogModel
    {
        public int Id { get; set; }

        public int PizzaSizeId { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public double Price { get; set; }

        public ICollection<Topping> Toppings { get; set; }
    }
}
