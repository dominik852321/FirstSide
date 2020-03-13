using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRestaurantRepository _Repository;
        private readonly IWebHostEnvironment _env;
     

        public MyAccountController(IRestaurantRepository repo, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {

            _Repository = repo;
            _env = env;
            _userManager = userManager;
          
        }


        public IActionResult MyRestaurants()
        {
            var user = _userManager.GetUserAsync(HttpContext.User);
            var userT = _Repository.GetUser(user.Result.Id);

            var homeVM = new HomeVM
            {
                Restaurants = userT.Restaurants.ToList(),
            };

            return View(homeVM);
        }

    }
}