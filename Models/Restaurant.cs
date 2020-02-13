using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string UserName { get; set; }
        public int Open { get; set; }
        public int Close { get; set; }
        public int BestPromotions { get; set; }
        public int postlike { get; set; }
        public Menu Menu { get; set;}
        public ICollection<Photo> photo { get; set; }
        public ICollection<EventRestaurant> EventRestaurants { get; set; }

    }
}
