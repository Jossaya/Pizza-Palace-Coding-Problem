using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Palace_Coding_Problem.ViewModels
{
    public class Cart
    {

        public int Id { get; set; }

        public int PizzaSizeId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
        public bool ItemIsATopping { get; set; }
    }
}
