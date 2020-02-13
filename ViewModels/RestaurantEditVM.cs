using FirstSide.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.ViewModels
{
    public class RestaurantEditVM
    {
        public IFormFile PhotoFile { get; set; }
        public Restaurant Restaurant { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
