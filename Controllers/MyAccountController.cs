using FirstSide.Interface;
using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        
        public IActionResult MyLocals()
        {
            var user = _userManager.GetUserAsync(HttpContext.User);
            var userT = _Repository.GetUser(user.Result.Id);

            var homeVM = new HomeVM
            {
                Restaurants = userT.Restaurants.ToList(),
                Clubs = userT.Clubs.ToList()
            };

            return View(homeVM);
        }

        [HttpGet]
        public IActionResult DetailsRestaurant(int id)
        {
            var restaurant = _Repository.GetRestaurant(id);
            return View(restaurant);
        }

        [HttpGet]
        public IActionResult DetailsClub(int id)
        {
            var club = _RepositoryClub.GetClub(id);
            return View(club);
        }

    }
}