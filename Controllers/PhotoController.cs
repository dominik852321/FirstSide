using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace FirstSide.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoRepository _photo;
        private readonly IWebHostEnvironment _env;
        public PhotoController(IPhotoRepository photos, IWebHostEnvironment env)
        {
            _photo = photos;
            _env = env;

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhotoVM model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if(model.PhotoFile!=null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath,"Image");
                    uniqueFileName=Guid.NewGuid().ToString() + "_" + model.PhotoFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PhotoFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Photo newPhoto = new Photo
                { Name = model.Name,
                  ZdjecieUrl = uniqueFileName
                };

                _photo.DodajZdjecie(newPhoto);
                return RedirectToAction("Successful", new { id = newPhoto.Id });

            }

            return View();
        }

        public IActionResult Successful()
        {
            return View();
        }



       
    }
}