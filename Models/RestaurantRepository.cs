using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
   
    public class RestaurantRepository: IRestaurantRepository
    {
        private readonly AppDbContext _appDbContext;

        public RestaurantRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Restaurant> restaurants()
        {
            return _appDbContext.Restaurants
                .Include(c=>c.EventRestaurants)
                .ThenInclude(c=>c.Event)
                .Include(s=>s.UserRestaurants)
                .ThenInclude(s=>s.ApplicationUser);
        }
        public IEnumerable<Event> events()
        {
            return _appDbContext.Events;
        }

     

        public Restaurant Pobierzrestaurant(int restaurantId)
        {
            return  _appDbContext.Restaurants.Include(c => c.EventRestaurants).ThenInclude(c => c.Event)
                                            .Include(c => c.photo)
                                            .FirstOrDefault(s => s.Id == restaurantId);
        }



        public void Dodajrestaurant(Restaurant restaurant)
        {
            _appDbContext.Restaurants.Add(restaurant);
            _appDbContext.SaveChanges();
        }

        public void Usunrestaurant(Restaurant restaurant)
        {
            _appDbContext.Restaurants.Remove(restaurant);
            _appDbContext.SaveChanges();
        }

     
      

       
    }
}
