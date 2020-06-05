using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Palace_Coding_Problem.Core.Models
{
    /// <summary>
    /// Acts as a transformation object for OrderItem Entity
    /// </summary>
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public double UnitPrice { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
    }
}
