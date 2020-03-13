using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
    public class ApplicationUser:IdentityUser
    {
        
        public string City { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; } 
        public ICollection<Club> Clubs { get; set; }

     
    }
}
