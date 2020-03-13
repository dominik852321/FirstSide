using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
    public class EventRestaurant
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string PhotoUrl { get; set; }



        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        public int People { get; set; }

        public string Place { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
