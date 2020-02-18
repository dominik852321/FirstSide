using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> restaurants();

        IEnumerable<Event> events();

        Restaurant Pobierzrestaurant(int restaurantId);

        void Dodajrestaurant(Restaurant restaurant);
        void Usunrestaurant(Restaurant restaurant);
       


    }
}
