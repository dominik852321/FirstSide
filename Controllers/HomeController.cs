using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRestaurantRepository _restaurant;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _appDbContext;



        public HomeController(UserManager<ApplicationUser> userManager, IRestaurantRepository photos, IWebHostEnvironment env, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _restaurant = photos;
            _env = env;
            _appDbContext = appDbContext;

        }


        public IActionResult Index()
        {

            var restaurants = _restaurant.restaurants();

            var homeVM = new HomeVM()
            {
                Restaurants = restaurants.ToList()
            };


            return View(homeVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, string ZdjecieUrl)
        {
            var restaurant = _restaurant.Pobierzrestaurant(id);
            _restaurant.Usunrestaurant(restaurant);

            if (ZdjecieUrl != null)
            {
                var webRoot = _env.WebRootPath;
                var filePath = Path.Combine(webRoot.ToString() + ZdjecieUrl);
                System.IO.File.Delete(filePath);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Information(int Id)
        {
            var restaurant = _restaurant.Pobierzrestaurant(Id);
            var menu = _appDbContext.Menus.FirstOrDefault(s => s.RestaurantId == Id);

            if (restaurant == null)
                return View("Index");

            RestaurantMenu restaurantMenu = new RestaurantMenu
            {
                Restaurant = restaurant,
                Menu = menu
            };
            return View(restaurantMenu);
        }

        [HttpGet]
        public IActionResult Events()
        {
            var events = _restaurant.events();
            var homeVM = new HomeVM()
            {
                Events = events.ToList()
            };
            return View(homeVM);
        }


        [HttpPost]
        public async Task<string> LikeThis(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var restaurant = _restaurant.Pobierzrestaurant(id);
            restaurant.postlike++;
            UserRestaurant userRestaurant = new UserRestaurant
            {
                ApplicationUser = user,
                Restaurant = restaurant
            };
            _appDbContext.Add(userRestaurant);
            _appDbContext.Restaurants.Update(restaurant);
            _appDbContext.SaveChanges();


            return restaurant.postlike.ToString();
        }

        [HttpPost]
        public string UnlikeThis(int id)
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            var restaurant = _restaurant.Pobierzrestaurant(id);

            var UR = _appDbContext.UserRestaurants.FirstOrDefault(s => s.RestaurantId == restaurant.Id && s.UserId == userid);
              
            restaurant.postlike--;
           
            _appDbContext.UserRestaurants.Remove(UR);
            _appDbContext.Restaurants.Update(restaurant);
            _appDbContext.SaveChanges();
    
            return restaurant.postlike.ToString();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
