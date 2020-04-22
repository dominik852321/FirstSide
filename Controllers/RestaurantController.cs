using FirstSide.Interface;
using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FirstSide.Controllers
{

    //Problem z tokenami podczas wysyłania pliku ajaxem
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
            var restaurants = _Repository.GetRestaurants().Result;

            return View(restaurants);
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
                    ResizeImage(model.PhotoFile.OpenReadStream(), filePath);
                }
                Restaurant restaurant = new Restaurant
                {
                    Name = model.Name,
                    ZdjecieUrl = uniqueFileName,
                    City = model.City,
                    User = user.Result,
                };

                _Repository.AddRestaurant(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View("Model is not valid");
        }

        private static void ResizeImage(Stream stream, string filePath)
        {
            using (Image image = Image.Load(stream))
            {
                image.Mutate(x => x.Resize(image.Size()/4));
                image.Save(filePath);
            }
        }

       

        [HttpGet]
        public IActionResult Details(int id)
        {
            var restaurant = _Repository.GetRestaurantAndUpdateVisitators(id).Result;

            var details = new RestaurantOpinionVM
            {
                Restaurant = restaurant,
                CommentVM = new CommentVM
                {
                    Id = id,
                }
            };
            return View(details);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var restaurant = _Repository.GetRestaurant(id).Result;
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
            var restaurant = _Repository.GetRestaurant(id).Result;
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

                    string uploadsFolder = Path.Combine(_env.WebRootPath, "ImageRestaurant");
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
            var photo = _Repository.GetPhoto(id).Result;
            var restaurant = _Repository.GetRestaurant(photo.Restaurant.Id).Result;

            if (photo != null && restaurant != null)
            {
                _Repository.RemovePhoto(id);
                _Repository.UpdateRestaurant(restaurant);

                var deleteEnv = Path.Combine(_env.WebRootPath, "ImageRestaurant", photo.Zdjecie);
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
            var restaurant = _Repository.GetRestaurant(id).Result;
            var Photos = _Repository.GetPhotos(id).Result;


            _Repository.RemoveRestaurant(id);
            if (restaurant.ZdjecieUrl != null)
            {
                var deleteEnv = Path.Combine(_env.WebRootPath, "ImageRestaurant", restaurant.ZdjecieUrl);
                FileInfo file = new FileInfo(deleteEnv);
                System.IO.File.Delete(deleteEnv);
                file.Delete();
            }


            _Repository.RemovePhotos(Photos);

            var deleteEnv1 = Path.Combine(_env.WebRootPath, "ImageRestaurant", Photos.ToString());

            FileInfo file1 = new FileInfo(deleteEnv1);
            if (file1 != null)
            {
                System.IO.File.Delete(deleteEnv1);
                file1.Delete();
            };

            return RedirectToAction("Index", "MyAccount");
        }

        [HttpGet]
        public IActionResult SearchRestaurant(string CurrentFilterName, string CurrentFilterCity)
        {

            ViewBag.CurrentFilterName = CurrentFilterName;
            ViewBag.CurrentFilterCity = CurrentFilterCity;

            var restaurant = _Repository.SearchData(CurrentFilterName, CurrentFilterCity).Result;

            return PartialView("_Restaurants", restaurant);
        }

        [HttpGet]
        public IActionResult SortedRestaurant(int WhichSort)
        {
            var restaurant = _Repository.SortedBy(WhichSort).Result;
            return PartialView("_Restaurants", restaurant);
        }



        [HttpPost]
        public IActionResult AddComment(CommentVM commentVM)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetUserAsync(HttpContext.User);
                var date = DateTime.Now;
                var Comment = new Comment
                {
                    RestaurantId = commentVM.Id,
                    Description = commentVM.Description,
                    Rating = commentVM.Rating,
                    User = user.Result,
                    TimeInsert = date
                };
                _Repository.AddComment(Comment);
                return RedirectToAction("Details", new { id = commentVM.Id });
            }

            return View("Model is not valid");
        }



    }














}
