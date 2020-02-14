using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace FirstSide.Controllers
{

    public class RestaurantController : Controller
    {

        private readonly IRestaurantRepository _restaurant;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;


        public RestaurantController(IRestaurantRepository restaurant, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, AppDbContext appDbContext)
        {

            _restaurant = restaurant;
            _env = env;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(RestaurantVM model)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = null;

                model.restaurant.postlike = 0;
                model.restaurant.BestPromotions = 0;
                model.restaurant.Open = 0;
                model.restaurant.Close = 0;

                var user = await _userManager.GetUserAsync(HttpContext.User);


                if (model.PhotoFile != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Image");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PhotoFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Restaurant newRestaurant = new Restaurant
                {
                    Name = model.restaurant.Name,
                    ZdjecieUrl = uniqueFileName,
                    postlike = model.restaurant.postlike,
                    City = model.restaurant.City,
                    BestPromotions = model.restaurant.BestPromotions,
                    UserName = user.UserName,
                    Open = model.restaurant.Open,
                    Close = model.restaurant.Close



                };

                _restaurant.Dodajrestaurant(newRestaurant);
                return RedirectToAction("Successful", new { id = newRestaurant.Id });

            }

            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddMenu(int id)
        {
            var restaurant = _appDbContext.Restaurants.FirstOrDefault(s => s.Id == id);
            var NewMenu = new RestaurantMenu
            {
                Restaurant = restaurant,
            };

            return View(NewMenu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMenu(RestaurantMenu restaurantMenu)
        {
            var restaurant = _appDbContext.Restaurants.FirstOrDefault(s => s.Id == restaurantMenu.Restaurant.Id);
            Menu NewMenu = new Menu
            {
                Alcohol = restaurantMenu.Menu.Alcohol,
                Drink = restaurantMenu.Menu.Drink,
                Foods = restaurantMenu.Menu.Foods,
                Pizza = restaurantMenu.Menu.Pizza,
                Restaurant = restaurant
            };
            _appDbContext.Menus.Add(NewMenu);
            _appDbContext.Entry(restaurant).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return RedirectToAction("Successful");

        }

        [HttpGet]
        [Authorize]
        public IActionResult EditMenu(int id)
        {
            var menu = _appDbContext.Menus.FirstOrDefault(s => s.Id == id);
            var restaurant = _appDbContext.Restaurants.FirstOrDefault(s => s.Id == menu.RestaurantId);
            if (menu != null)
            {
                RestaurantMenu NewMenu = new RestaurantMenu
                {
                    Menu = menu,
                    Restaurant = restaurant
                };
                return View(NewMenu);
            }

            return View("Not Found");
        }

        [HttpPost]
        public IActionResult EditMenu(Menu menu)
        {
            if (menu != null)
            {
                _appDbContext.Menus.Update(menu);
                _appDbContext.SaveChanges();
                return RedirectToAction("Information", "Home", new { Id = menu.RestaurantId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditInformation(int id)
        {
            Restaurant restaurant = _restaurant.Pobierzrestaurant(id);

            return View(restaurant);
        }

        [HttpPost]
        public IActionResult EditInformation(Restaurant restaurant)
        {

            if (restaurant != null)
            {
                _appDbContext.Restaurants.Update(restaurant);
                _appDbContext.SaveChanges();
                return RedirectToAction("Information", "Home", restaurant);
            }

            return View();
        }


        [Authorize]
        public IActionResult Successful()
        {
            return View();
        }




        [HttpPost]
        public ActionResult UploadFiles(int id)
        {

            var restaurant = _appDbContext.Restaurants.FirstOrDefault(s => s.Id == id);

            try
            {
                long size = 0;
                var file = Request.Form.Files;
                var filename = ContentDispositionHeaderValue
                                .Parse(file[0].ContentDisposition)

                                .FileName

                                .Trim('"');

                string uploadsFolder = Path.Combine(_env.WebRootPath, "Image");
                string FilePath = Path.Combine(uploadsFolder + $@"\{ filename}");
                size += file[0].Length;
                using (FileStream fs = System.IO.File.Create(FilePath))
                {
                    file[0].CopyTo(fs);
                    fs.Flush();
                }
                Photo photo = new Photo
                {
                    Restaurant = restaurant,
                    Zdjecie = filename
                };
                _appDbContext.Photos.Add(photo);
                _appDbContext.Entry(restaurant).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                return PartialView("_Photos", restaurant);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }



        [HttpPost]
        public ActionResult DeletePhoto(int id)
        {

            var photo = _appDbContext.Photos.FirstOrDefault(s => s.Id == id);
            var rid = photo.Restaurantid;
            var restaurant = _appDbContext.Restaurants.FirstOrDefault(s => s.Id == rid);

            _appDbContext.Photos.Remove(photo);
            _appDbContext.Entry(restaurant).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            var deleteEnv = Path.Combine(_env.WebRootPath, "Image", photo.Zdjecie);
            FileInfo file = new FileInfo(deleteEnv);
            if (file != null)
            {
                System.IO.File.Delete(deleteEnv);
                file.Delete();
            }


            return PartialView("_Photos", restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _appDbContext.Restaurants.FirstOrDefaultAsync(s => s.Id == id);

            var Photos = _appDbContext.Photos
                .Where(s => s.Restaurantid == restaurant.Id)
                .ToList();


            _appDbContext.Restaurants.Remove(restaurant);

            _appDbContext.Photos.RemoveRange(Photos);

            var deleteEnv = Path.Combine(_env.WebRootPath, "Image", restaurant.ZdjecieUrl);
            var deleteEnv1 = Path.Combine(_env.WebRootPath, "Image", Photos.ToString());

            FileInfo file = new FileInfo(deleteEnv);
            FileInfo file1 = new FileInfo(deleteEnv1);
            if (file != null && file1 != null)
            {
                System.IO.File.Delete(deleteEnv);
                System.IO.File.Delete(deleteEnv1);
                file.Delete();
                file1.Delete();
            };
            _appDbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }














    }
}