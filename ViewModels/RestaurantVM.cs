using FirstSide.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FirstSide.ViewModels
{
    public class RestaurantVM
    {

        public IFormFile PhotoFile { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

    }
}
