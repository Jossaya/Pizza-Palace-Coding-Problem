using Pizza_Palace_Coding_Problem.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Palace_Coding_Problem.Core.Models
{
    /// <summary>
    /// Acts as a transformation object for Topping Entity
    /// </summary>
    public class ToppingCatalogModel
    {
        public int Id { get; set; }
        public int PizzaSizeId { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public int ToppingCategoryId { get; set; }
        public ToppingCategory ToppingCategory { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
