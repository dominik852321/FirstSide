using FirstSide.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.ViewModels
{
    public class RestaurantMenu
    {

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        [Range(0, 100)]
        public int PizzaPromotions { get; set;}
       
        [Range(0, 100)]
        public int FoodPromotions { get; set; }
       
        [Range(0, 100)]
        public int DrinkPromotions { get; set; }
    
        [Range(0, 100)]
        public int AlcoholPromotions { get; set; }
       



    }
}
