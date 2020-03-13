
using FirstSide.Interface;
using FirstSide.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FirstSide.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<EventRestaurant> GetEventsRestaurants()
        {
            var result = _appDbContext.EventRestaurants.Include(s => s.Restaurant);
            return result;
        }
        public IEnumerable<EventClub> GetEventClubs()
        {
            var result = _appDbContext.EventClubs.Include(s => s.Club);
            return result;
        }

        public EventClub GetEventClub(int id)
        {
            var result = _appDbContext.EventClubs.Include(s => s.Club)
                                              .FirstOrDefault(s => s.Id == id);
            return result;
        }

        public EventRestaurant GetEventRestaurant(int id)
        {
            var result = _appDbContext.EventRestaurants.Include(s => s.Restaurant)
                                             .FirstOrDefault(s => s.Id == id);
            return result;
        }

        public void AddEventRestaurant(EventRestaurant model)
        {
            _appDbContext.EventRestaurants.Add(model);
            _appDbContext.SaveChanges();
        }

        public void RemoveEventRestaurant(int id)
        {
            var Event = _appDbContext.EventRestaurants.FirstOrDefault(s => s.Id == id);
            _appDbContext.EventRestaurants.Remove(Event);
            _appDbContext.SaveChanges();
        }

        public void UpdateEventRestaurant(EventRestaurant model)
        {
            _appDbContext.EventRestaurants.Update(model);
            _appDbContext.SaveChanges();
        }

       

       

        public void AddEventClub(EventClub model)
        {
            _appDbContext.EventClubs.Add(model);
            _appDbContext.SaveChanges();
        }

        public void RemoveEventClub(int id)
        {
            var Event = _appDbContext.EventClubs.FirstOrDefault(s => s.Id == id);
            _appDbContext.EventClubs.Remove(Event);
            _appDbContext.SaveChanges();
        }

        public void UpdateEventClub(EventClub model)
        {
            _appDbContext.EventClubs.Update(model);
            _appDbContext.SaveChanges();
        }
    }
}
