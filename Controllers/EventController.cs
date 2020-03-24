using FirstSide.Interface;
using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Controllers
{

    //dodać tokeny na końcu
    public class EventController : Controller
    {

        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEventRepository _RepositoryEvent;



        public EventController(IEventRepository repo, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _env = env;
            _userManager = userManager;
            _RepositoryEvent = repo;


        }

        [HttpGet]
        public IActionResult Events()
        {
            var events = _RepositoryEvent.GetEventsRestaurants();
            var homeVM = new HomeVM()
            {
                EventRestaurant = events.ToList()
            };
            return View(homeVM);
        }

        [HttpGet]
        public IActionResult Party()
        {
            var events = _RepositoryEvent.GetEventClubs();
            var homeVM = new HomeVM()
            {
                EventClubs = events.ToList()
            };

            return View(homeVM);
        }



        [HttpGet]
        public IActionResult AddEvent(int id)
        {
            var NewEvent = new EventVM
            {
                RestaurantId = id
            };
            return View(NewEvent);
        }


        [HttpPost]
        public async Task<IActionResult> AddEvent(EventVM model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = _RepositoryEvent.GetRestaurant(model.RestaurantId);
                string uniqueFileName = null;


                if (model.File != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "ImageEvent");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    await model.File.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }

                EventRestaurant newEvent = new EventRestaurant
                {
                    EventName = model.Name,
                    DateStart = model.DateStart,
                    DateEnd = model.DateEnd,
                    PhotoUrl = uniqueFileName,
                    Place = model.Place,
                    Restaurant = restaurant
                };
                _RepositoryEvent.AddEventRestaurant(newEvent);

                return RedirectToAction(nameof(Events));
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddParty(int id)
        {
            if (id>0)
            {
                var eventParty = new EventPartyVM
                {
                    ClubId = id
                };
                return View(eventParty);
            }
            return View("Not found");
        }


        [HttpPost]
        public async Task<IActionResult> AddParty(EventPartyVM model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                var club = _RepositoryEvent.GetClub(model.ClubId);

                if (model.File != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "ImageEvent");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    await model.File.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }

                EventClub eventClub = new EventClub
                {
                    EventName = model.Name,
                    DateStart = model.TimeStart,
                    DateEnd = model.TimeEnd,
                    Club = club,
                    Place = club.Address,
                    PhotoUrl = uniqueFileName
                };

                _RepositoryEvent.AddEventClub(eventClub);
                return RedirectToAction(nameof(Party));
            }
            return View();
        }




    }
}