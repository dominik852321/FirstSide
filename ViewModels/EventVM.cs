using FirstSide.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace FirstSide.ViewModels
{
    public class EventVM
    {
        public int RestaurantId { get; set; }
       

        public string Place { get; set; }
        public string Name { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public IFormFile File { get; set; }

    }
}
