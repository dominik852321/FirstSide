using System.Collections.Generic;

namespace FirstSide.Models
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurants();
        IEnumerable<Photo> GetPhotos(int restaurantid);

        
        Restaurant GetRestaurant(int id);
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
