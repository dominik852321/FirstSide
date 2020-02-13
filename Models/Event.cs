using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstSide.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string PhotoUrl { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}}")]
        public DateTime DateEnd { get; set; }

        public int People { get; set; }

        public string Place { get; set; }

        
        public ICollection<EventRestaurant> EventRestaurants { get; set; }

    }
}
