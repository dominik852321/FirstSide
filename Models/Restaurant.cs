﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FirstSide.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot have above 50 characters")]
        public string Name { get; set; }
        public string ZdjecieUrl { get; set; }
        public string City { get; set; }
        public int Open { get; set; }
        public int Close { get; set; }
        public bool IsOpen()
        {
            if (DateTime.Now.TimeOfDay.TotalHours < Close 
                && DateTime.Now.TimeOfDay.TotalHours > Open)
                return true;
            else
                return false;
        }

        public string Address { get; set; }
        public int Number { get; set; }
        public int PostCode { get; set; }

        public int Visitators { get; set; }

        public string Description { get; set; }


        public ICollection<Comment> Comments { get; set; }
        public string Average()
        {
            float marks = 0;
            foreach(var item in Comments)
            {
                marks = marks + item.Rating;
            };
            if (Comments.Count > 0)
            {
                float wynik = marks / Comments.Count;
                return wynik.ToString("0.00");
            }
            else
                return null;
        }
        public Menu Menu { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Photo> photo { get; set; }
        public ICollection<EventRestaurant> EventRestaurants { get; set; }

    }
}
