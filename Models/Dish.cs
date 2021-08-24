using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        public string DishName {get;set;}
        [Required]
        [Range(1, 10000)]
        public int Calories {get;set;}
        [Required]
        public int Taste {get;set;}
        [Required]
        public string Description {get;set;}
        public int ChefId {get;set;}
        public Chef Creator {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}