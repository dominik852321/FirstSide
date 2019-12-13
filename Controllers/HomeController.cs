using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace FirstSide.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPhotoRepository _photo;
        

        public HomeController(IPhotoRepository photos)
        {
            _photo = photos;
          
        }

       
        public IActionResult Index()
        {
            var zdjecia = _photo.zdjecia();

            var homeVM = new HomeVM()
            {
                Zdjęcia = zdjecia.ToList()
            };

            return View(homeVM);
        }

       



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
