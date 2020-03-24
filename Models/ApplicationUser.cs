using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FirstSide.Models
{
    public class ApplicationUser:IdentityUser
    {
        
        public string City { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; } 
        public ICollection<Club> Clubs { get; set; }

     
    }
}
