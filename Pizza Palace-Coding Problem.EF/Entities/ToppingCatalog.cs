using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pizza_Palace_Coding_Problem.EF.Entities
{
    public class Topping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PizzaSizeId { get; set; }

        [ForeignKey("PizzaSizeId")]
        public PizzaSize PizzaSize { get; set; }
        public int ToppingCategoryId { get; set; }

        [ForeignKey("ToppingCategoryId")]
        public ToppingCategory ToppingCategory { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
