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

    [AutoValidateAntiforgeryToken]
    public class EventController : Controller
    {

        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEventRepository _RepositoryEvent;
        private readonly IRestaurantRepository _RepositoryRestaurant;


        public EventController(IEventRepository repo, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, IRestaurantRepository repo2)
        {
            _env = env;
            _userManager = userManager;
            _RepositoryEvent = repo;
            _RepositoryRestaurant = repo2;
         
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
        public IActionResult AddEvent(int id)
        {
            var restaurant = _RepositoryRestaurant.GetRestaurant(id);
            var NewEvent = new EventVM
            {
                RestaurantId=restaurant.Id
            };
            return View(NewEvent);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(EventVM model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = _RepositoryRestaurant.GetRestaurant(model.RestaurantId);
                string uniqueFileName = null;
             
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (model.File != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "ImageEvent");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                 EventRestaurant newEvent = new EventRestaurant
                {
                    EventName = model.Name,
                    DateStart = model.DateStart,
                    DateEnd= model.DateEnd,
                    PhotoUrl = uniqueFileName,
                    Place= model.Place,
                    Restaurant=restaurant
                };
                _RepositoryEvent.AddEventRestaurant(newEvent);
                _RepositoryRestaurant.UpdateRestaurant(restaurant);

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