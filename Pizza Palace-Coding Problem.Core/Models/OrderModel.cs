using Pizza_Palace_Coding_Problem.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Palace_Coding_Problem.Core.Models
{
    /// <summary>
    /// Acts as a transformation object for Order Entity
    /// </summary>
    public class OrderModel
    {
        public int Id { get; set; }
        public double SubTotal { get; set; }
        public double TaxTotal { get; set; }
        public double Total { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
