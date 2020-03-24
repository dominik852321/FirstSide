using FirstSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.ViewModels
{
    public class HomeVM
    {
        public List<Restaurant> Restaurants { get; set; }

        public List<Club> Clubs { get; set; }
        public List<EventRestaurant> EventRestaurant { get; set; }
        public List<EventClub> EventClubs { get; set; }


    }
}
