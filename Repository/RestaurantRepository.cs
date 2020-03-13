using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FirstSide.Models
{

    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _appDbContext;

        public RestaurantRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public IEnumerable<Restaurant> GetRestaurants()
        {
            var result = _appDbContext.Restaurants.Include(s => s.photo)
                                                  .Include(s => s.User)
                                                  .Include(s => s.Menu)
                                                  .Include(s => s.EventRestaurants);
                                                 
            return result;
        }
        

        public IEnumerable<Photo> GetPhotos(int restaurantid)
        {
            var result = _appDbContext.Photos.Where(s => s.RestaurantId == restaurantid).ToList();
            return result;
        }


        public Restaurant GetRestaurant(int id)
        {
            var result = _appDbContext.Restaurants.Include(s => s.photo)
                                                  .Include(s => s.User)
                                                  .Include(s => s.Menu)
                                                  .Include(s => s.EventRestaurants)
                                                  .FirstOrDefault(s => s.Id == id);
            return result;
        }


        public Menu GetMenu(int id)
        {
            var result = _appDbContext.Menus.Include(s => s.Restaurant)
                                           .FirstOrDefault(s => s.Id == id);
            return result;
        }
        public Photo GetPhoto(int id)
        {
            var result = _appDbContext.Photos.Include(s => s.Restaurant)
                                           .FirstOrDefault(s => s.Id == id);
            return result;
        }
        public ApplicationUser GetUser(string id)
        {
            var result = _appDbContext.Users.Include(s => s.Restaurants).Include(s=>s.Clubs)
                                            .FirstOrDefault(s => s.Id == id);
            return result;
        }

        public void AddRestaurant(Restaurant model)
        {
            var RestaurantCount = (from restaurant in _appDbContext.Restaurants
                                   where restaurant.Name == restaurant.Name
                                   select restaurant).Count();
            if (RestaurantCount==0)
            {
                _appDbContext.Restaurants.Add(model);
                _appDbContext.SaveChanges();
            }
           
        }

        public void UpdateRestaurant(Restaurant model)
        {

            _appDbContext.Restaurants.Update(model);
            _appDbContext.SaveChanges();
        }

        public void RemoveRestaurant(int Id)
        {
            var restaurant = _appDbContext.Restaurants.FirstOrDefault(s => s.Id == Id);
            _appDbContext.Restaurants.Remove(restaurant);
            _appDbContext.SaveChanges();
        }

        public void AddMenu(Menu model)
        {
            _appDbContext.Menus.Add(model);
            _appDbContext.SaveChanges();
        }

        public void UpdateMenu(Menu model)
        {
            _appDbContext.Menus.Update(model);
            _appDbContext.SaveChanges();
        }

        public void AddPhoto(Photo model)
        {
            _appDbContext.Photos.Add(model);
            _appDbContext.SaveChanges();
        }
        public void RemovePhoto(int id)
        {
            var photo = _appDbContext.Photos.FirstOrDefault(s => s.Id == id);
            _appDbContext.Photos.Remove(photo);
            _appDbContext.SaveChanges();
        }
        public void RemovePhotos(IEnumerable<Photo> photos)
        {
            foreach (var photo in photos)
            {
                _appDbContext.Photos.Remove(photo);
            }
            _appDbContext.SaveChanges();
        }

       
    }
}
