using FirstSide.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FirstSide.ViewModels
{
    public class RestaurantVM
    {

        public IFormFile PhotoFile { get; set; }

        public Restaurant restaurant { get; set; }

       


    }
}
