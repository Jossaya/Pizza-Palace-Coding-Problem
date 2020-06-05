using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza_Palace_Coding_Problem.EF.Entities
{
   public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public int ItemId { get; set; }
        public bool ItemIsATopping { get; set; }

    }
}
