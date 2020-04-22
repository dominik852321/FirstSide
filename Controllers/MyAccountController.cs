using FirstSide.Interface;
using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRestaurantRepository _Repository;
        private readonly IClubRepository _RepositoryClub;
        private readonly IWebHostEnvironment _env;



        public MyAccountController(IRestaurantRepository repo, IClubRepository club, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _RepositoryClub = club;
            _Repository = repo;
            _env = env;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var userT = _Repository.GetUser(user.Id).Result;

            var homeVM = new HomeVM
            {
                Restaurants = userT.Restaurants.ToList(),
                Clubs = userT.Clubs.ToList()
            };

            return View(homeVM);
        }

        [HttpGet]
        public ActionResult<Restaurant> DetailsRestaurant(int id)
        {
            var restaurant = _Repository.GetRestaurant(id).Result;
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult<Club> DetailsClub(int id)
        {
            var club = _RepositoryClub.GetClub(id).Result;
            return View(club);
        }

    }
}