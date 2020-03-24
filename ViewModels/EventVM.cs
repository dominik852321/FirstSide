using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace FirstSide.ViewModels
{
    public class EventVM
    {
       

        public int RestaurantId { get; set; }
        public string Place { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        public IFormFile File { get; set; }

    }
}
