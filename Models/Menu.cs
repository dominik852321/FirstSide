using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public int Pizza { get; set; }
        public int Alcohol { get; set; }
        public int Drink { get; set; }
        public int Foods { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
