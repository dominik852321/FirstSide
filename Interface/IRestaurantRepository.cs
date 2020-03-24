using FirstSide.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstSide.Interface
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurants();
        IEnumerable<Photo> GetPhotos(int restaurantid);
        IEnumerable<Restaurant> SearchData(string nameRestaurant, string nameCity);
        IEnumerable<Restaurant> SortedBy(int WhichSort);

        Restaurant GetRestaurant(int id);
        Restaurant GetRestaurantAndUpdateVisitators(int id);
        Menu GetMenu(int id);
        Photo GetPhoto(int id);
        ApplicationUser GetUser(string id);



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
