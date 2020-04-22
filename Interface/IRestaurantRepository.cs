using FirstSide.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstSide.Interface
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetRestaurants();
        Task<IEnumerable<Photo>> GetPhotos(int restaurantid);
        Task<IEnumerable<Restaurant>> SearchData(string nameRestaurant, string nameCity);
        Task<IEnumerable<Restaurant>> SortedBy(int WhichSort);

        Task<Restaurant> GetRestaurant(int id);
        Task<Restaurant> GetRestaurantAndUpdateVisitators(int id);
        Task<Menu> GetMenu(int id);
        Task<Photo> GetPhoto(int id);
        Task<ApplicationUser> GetUser(string id);


        void AddComment(Comment model);
        void AddRestaurant(Restaurant model);
        void UpdateRestaurant(Restaurant model);
        void RemoveRestaurant(int Id);

        void AddMenu(Menu model);
        void UpdateMenu(Menu model);

        void AddPhoto(Photo model);
        void RemovePhoto(int id);
        void RemovePhotos(IEnumerable<Photo> photos);




    }
}
