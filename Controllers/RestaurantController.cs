using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FirstSide.Controllers
{


    public class RestaurantController : Controller
    {

        private readonly IRestaurantRepository _Repository;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;


        public RestaurantController(IRestaurantRepository repo, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {

            _Repository = repo;
            _env = env;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var restaurants = _Repository.GetRestaurants();
            var homeVM = new HomeVM()
            {
                Restaurants = restaurants.ToList()
            };

            return View(homeVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(RestaurantVM model)
        {
            if (ModelState.IsValid && model.Name.Length != 0)
            {
                string uniqueFileName = null;
                var user = _userManager.GetUserAsync(HttpContext.User);

                if (model.PhotoFile != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "ImageRestaurant");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PhotoFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Restaurant restaurant = new Restaurant
                {
                    Name = model.Name,
                    ZdjecieUrl = uniqueFileName,
                    City = model.City,
                    User = user.Result,
                };

                _Repository.AddRestaurant(restaurant);
                return RedirectToAction("Successful");
            }

            return View("Model is not valid");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var restaurant = _Repository.GetRestaurant(id);
            return View(restaurant);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var restaurant = _Repository.GetRestaurant(id);
            if (restaurant != null)
            {
                return View(restaurant);
            }

            return View("Not Found");
        }

        [HttpPost]
        public IActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _Repository.UpdateRestaurant(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View("Model is not valid");
        }

        [HttpGet]
        public IActionResult Successful()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles(int id)
        {
            var restaurant = _Repository.GetRestaurant(id);
            if (restaurant != null)
            {

                try
                {
                    long size = 0;
                    var file = Request.Form.Files;
                    var filename = ContentDispositionHeaderValue
                                    .Parse(file[0].ContentDisposition)

                                    .FileName

                                    .Trim('"');

                    string uploadsFolder = Path.Combine(_env.WebRootPath, "ImagePhoto");
                    string FilePath = Path.Combine(uploadsFolder + $@"\{ filename}");
                    size += file[0].Length;
                    using (FileStream fs = System.IO.File.Create(FilePath))
                    {
                        file[0].CopyTo(fs);
                        fs.Flush();
                    }
                    Photo photo = new Photo
                    {
                        Club = null,
                        Restaurant = restaurant,
                        Zdjecie = filename
                    };

                    _Repository.AddPhoto(photo);
                    _Repository.UpdateRestaurant(restaurant);

                    return PartialView("_Photos", restaurant);
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            return View("Model is not valid");

        }



        [HttpPost]
        public ActionResult DeletePhoto(int id)
        {
            var photo = _Repository.GetPhoto(id);
            var restaurant = _Repository.GetRestaurant(photo.Restaurant.Id);

            if (photo != null && restaurant != null)
            {
                _Repository.RemovePhoto(id);
                _Repository.UpdateRestaurant(restaurant);

                var deleteEnv = Path.Combine(_env.WebRootPath, "ImagePhoto", photo.Zdjecie);
                FileInfo file = new FileInfo(deleteEnv);
                if (file != null)
                {
                    System.IO.File.Delete(deleteEnv);
                    file.Delete();
                }

                return PartialView("_Photos", restaurant);
            }

            return View("Model is not valid");
        }

        [HttpPost]
        public IActionResult DeleteRestaurant(int id)
        {
            var restaurant = _Repository.GetRestaurant(id);
            var Photos = _Repository.GetPhotos(id);


            _Repository.RemoveRestaurant(id);
            if (restaurant.ZdjecieUrl != null)
            {
                var deleteEnv = Path.Combine(_env.WebRootPath, "ImageRestaurant", restaurant.ZdjecieUrl);
                FileInfo file = new FileInfo(deleteEnv);
                System.IO.File.Delete(deleteEnv);
                file.Delete();
            }


            _Repository.RemovePhotos(Photos);

            var deleteEnv1 = Path.Combine(_env.WebRootPath, "ImagePhoto", Photos.ToString());

            FileInfo file1 = new FileInfo(deleteEnv1);
            if (file1 != null)
            {
                System.IO.File.Delete(deleteEnv1);
                file1.Delete();
            };

            return RedirectToAction("Index", "Restaurant");
        }

        [HttpGet]
        public IActionResult SearchRestaurant(string nameRestaurant, string nameCity)
        {

            ViewBag.CurrentFilterName = nameRestaurant;
            ViewBag.CurrentFilterCity = nameCity;

            var restaurant = _Repository.SearchData(nameRestaurant,nameCity);

            var homeVM = new HomeVM
            {
                Restaurants = restaurant.ToList()
            };

            return View("Index", homeVM);
        }



    }














}
