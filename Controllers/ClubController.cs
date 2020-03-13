using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstSide.Interface;
using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstSide.Controllers
{
    public class ClubController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IClubRepository _RepositoryClub;


        public ClubController(IClubRepository club, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _env = env;
            _RepositoryClub = club;
            _userManager = userManager;
        }



        [HttpGet]
        public IActionResult Clubs()
        {
            var clubs = _RepositoryClub.GetClubs();
            var homeVM = new HomeVM
            {
                Clubs = clubs.ToList(),
            };
            return View(homeVM);
    }
}
}
