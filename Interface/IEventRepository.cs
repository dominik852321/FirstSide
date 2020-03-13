using FirstSide.Models;
using System.Collections.Generic;

namespace FirstSide.Interface
{
    public interface IEventRepository
    {
        IEnumerable<EventRestaurant> GetEventsRestaurants();
        IEnumerable<EventClub> GetEventClubs();

        EventRestaurant GetEventRestaurant(int id);

        EventClub GetEventClub(int id);

        void AddEventRestaurant(EventRestaurant model);
        void RemoveEventRestaurant(int id);
        void UpdateEventRestaurant(EventRestaurant model);

        void AddEventClub(EventClub model);
        void RemoveEventClub(int id);
        void UpdateEventClub(EventClub model);
    }
}
