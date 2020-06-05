using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza_Palace_Coding_Problem.EF.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public double SubTotal { get; set; }
        [Required]
        public double TaxTotal { get; set; }
        [Required]
        public double Total { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
