using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstSide.Controllers
{
    public class EventController : Controller
    {

        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;


        public EventController(IWebHostEnvironment env, UserManager<ApplicationUser> userManager, AppDbContext appDbContext)
        {
            _env = env;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddEvent(int id)
        {
            var restaurant = _appDbContext.Restaurants.FirstOrDefault(s => s.Id == id);
            var NewEvent = new EventVM
            {
                Restaurant=restaurant
            };
            return View(NewEvent);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddEvent(EventVM model)
        {
            if (ModelState.IsValid)
            {
                Restaurant restaurant =_appDbContext.Restaurants.FirstOrDefault(s => s.Id == model.Restaurant.Id);
                string uniqueFileName = null;
                model.Event.People = 0;
                
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (model.File != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Image");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                 Event newEvent = new Event
                {
                    EventName = model.Event.EventName,
                    DateStart = model.Event.DateStart,
                    DateEnd= model.Event.DateEnd,
                    PhotoUrl = uniqueFileName,
                    UserName = user.UserName,
                    Place= model.Event.Place,
                };
                _appDbContext.Events.Add(newEvent);
                _appDbContext.SaveChanges();


                restaurant.EventRestaurants = new List<EventRestaurant>();
                EventRestaurant eventRestaurant = new EventRestaurant
                {
                    Restaurant = restaurant,
                    Event = newEvent
                };

                restaurant.EventRestaurants.Add(eventRestaurant);

                _appDbContext.Entry(restaurant).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                return RedirectToAction("Successful");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Successful()
        {

            return View();
        }

    }
}