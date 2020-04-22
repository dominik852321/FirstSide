using FirstSide.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstSide.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventRestaurant>> GetEventsRestaurants();
        Task<IEnumerable<EventClub>> GetEventClubs();

        Task<EventRestaurant> GetEventRestaurant(int id);
        Task<EventClub> GetEventClub(int id);

        Task<Club> GetClub(int id);
        Task<Restaurant> GetRestaurant(int id);

        void AddEventRestaurant(EventRestaurant model);
        void RemoveEventRestaurant(int id);
        void UpdateEventRestaurant(EventRestaurant model);

        void AddEventClub(EventClub model);
        void RemoveEventClub(int id);
        void UpdateEventClub(EventClub model);
    }
}
