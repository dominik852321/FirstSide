using FirstSide.Interface;
using FirstSide.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<EventRestaurant>> GetEventsRestaurants()
        {
            var result = await _appDbContext.EventRestaurants.Include(s => s.Restaurant).ToListAsync();

            return result;
        }
        public async Task<IEnumerable<EventClub>> GetEventClubs()
        {
            var result =await _appDbContext.EventClubs.Include(s => s.Club).ToListAsync();
            return result;
        }
        public async Task<Club> GetClub(int id)
        {
            var result = await _appDbContext.Clubs.FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }

        public async Task<Restaurant> GetRestaurant(int id)
        {
            var result = await _appDbContext.Restaurants.FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }

        public async Task<EventClub> GetEventClub(int id)
        {
            var result = await _appDbContext.EventClubs.Include(s => s.Club)
                                              .FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }

        public async Task<EventRestaurant> GetEventRestaurant(int id)
        {
            var result = await _appDbContext.EventRestaurants.Include(s => s.Restaurant)
                                             .FirstOrDefaultAsync(s => s.Id == id);
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
