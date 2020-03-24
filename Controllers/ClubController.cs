using System;
using System.Collections.Generic;
using System.IO;
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
    //dodać tokeny
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
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClubVM model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                var user = _userManager.GetUserAsync(HttpContext.User);

                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "ImageClub");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    await model.Photo.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }

                var club = new Club
                {
                    Name = model.Name,
                    City = model.City,
                    Address = model.Address,
                    Number = model.Number,
                    User = user.Result,
                    ZdjecieUrl = uniqueFileName
                };

                _RepositoryClub.AddClub(club);

                return RedirectToAction(nameof(Clubs));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SearchClub(string ClubName, string ClubCity)
        {
            ViewBag.ClubName = ClubName;
            ViewBag.ClubCity = ClubCity;

            var Club = _RepositoryClub.SearchClub(ClubName, ClubCity);

            var homeVM = new HomeVM
            {
                Clubs = Club.ToList()
            };
            return PartialView("_Clubs",homeVM.Clubs);
        }

       


    }
}
