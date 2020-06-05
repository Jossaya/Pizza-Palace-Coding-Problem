using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pizza_Palace_Coding_Problem.EF.Entities
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PizzaSizeId { get; set; }

        [ForeignKey("PizzaSizeId")]
        public PizzaSize PizzaSize { get; set; }
        public double Price { get; set; }

    }
}
