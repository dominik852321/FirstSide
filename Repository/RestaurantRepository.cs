using FirstSide.Interface;
using FirstSide.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Repository
{

    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _appDbContext;

        public RestaurantRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            var result = await _appDbContext.Restaurants.ToListAsync();

            return result;
        }


        public async Task<IEnumerable<Photo>> GetPhotos(int restaurantid)
        {
            var result = await _appDbContext.Photos.Where(s => s.RestaurantId == restaurantid).ToListAsync();
            return result;
        }


        public async Task<Restaurant> GetRestaurant(int id)
        {
            var result = await _appDbContext.Restaurants.Include(s => s.photo)
                                                  .Include(s => s.User)
                                                  .Include(s => s.Menu)
                                                  .Include(s => s.EventRestaurants)
                                                  .FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }

        public async Task<Restaurant> GetRestaurantAndUpdateVisitators(int id)
        {
            var result = await _appDbContext.Restaurants.Include(s => s.photo)
                                                  .Include(s => s.Menu)
                                                  .Include(s => s.EventRestaurants)
                                                  .Include(s => s.Comments)
                                                  .ThenInclude(s=>s.User)
                                                  .FirstOrDefaultAsync(s => s.Id == id);
            result.Visitators++;
            UpdateRestaurant(result);
            return result;    
        }


        public async Task<Menu> GetMenu(int id)
        {
            var result = await _appDbContext.Menus.Include(s => s.Restaurant)
                                           .FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }
        public async Task<Photo> GetPhoto(int id)
        {
            var result = await _appDbContext.Photos.Include(s => s.Restaurant)
                                           .FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }
        public async Task<ApplicationUser> GetUser(string id)
        {
            var result = await _appDbContext.Users.Include(s => s.Restaurants).Include(s => s.Clubs)
                                            .FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }


        public async Task<IEnumerable<Restaurant>> SearchData(string nameRestaurant, string nameCity)
        {
            var result =  from x in _appDbContext.Restaurants.Include(x => x.User) select x;

            if (!string.IsNullOrEmpty(nameRestaurant) && !string.IsNullOrEmpty(nameCity))
            {
                result = result.Where(x => x.Name.Contains(nameRestaurant) || x.City.Contains(nameCity));
            }

            if (!string.IsNullOrEmpty(nameCity))
            {
                result = result.Where(x => x.City.Contains(nameCity));
            }

            if (!string.IsNullOrEmpty(nameRestaurant))
            {
                result = result.Where(x => x.Name.Contains(nameRestaurant));
            }

            return await result.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> SortedBy(int WhichSort)
        {
            var result = from x in _appDbContext.Restaurants select x;

            switch(WhichSort)
            {
                case 1:
                    result = result.OrderByDescending(s => s.Visitators);
                    break;
                case 2:
                    result = result.OrderByDescending(s => s.Comments.Count);
                    break;
                case 3:
                    result = result.OrderByDescending(s => s.EventRestaurants.Count());
                    break;
                default:
                    break;
            }
            return await result.AsNoTracking().ToListAsync();
        }



        public void AddRestaurant(Restaurant model)
        {
            _appDbContext.Restaurants.Add(model);
            _appDbContext.SaveChanges();
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

        public void AddComment(Comment model)
        {
            _appDbContext.Comments.Add(model);
            _appDbContext.SaveChanges();
        }
    }
}
