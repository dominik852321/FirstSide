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
        public IActionResult Index()
        {
            var clubs = _RepositoryClub.GetClubs().Result;
            return View(clubs);
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

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchClub(string ClubName, string ClubCity)
        {
            ViewBag.ClubName = ClubName;
            ViewBag.ClubCity = ClubCity;

            var Club = _RepositoryClub.SearchClub(ClubName, ClubCity).Result;

            var homeVM = new HomeVM
            {
                Clubs = Club.ToList()
            };
            return PartialView("_Clubs",homeVM.Clubs);
        }

       
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var club = _RepositoryClub.GetClub(id).Result;

            var Photos = _RepositoryClub.GetPhotos(id).Result;

            _RepositoryClub.RemoveClub(id);
            
            if (club.ZdjecieUrl != null)
            {
                var deleteEnv = Path.Combine(_env.WebRootPath, "ImageClub", club.ZdjecieUrl);
                FileInfo file = new FileInfo(deleteEnv);
                System.IO.File.Delete(deleteEnv);
                file.Delete();
            }

            _RepositoryClub.RemovePhotos(Photos);

            var deleteEnv1 = Path.Combine(_env.WebRootPath, "ImageClub", Photos.ToString());

            FileInfo file1 = new FileInfo(deleteEnv1);
            if (file1 != null)
            {
                System.IO.File.Delete(deleteEnv1);
                file1.Delete();
            };

            return RedirectToAction("Index", "MyAccount");
        }

       


    }
}
