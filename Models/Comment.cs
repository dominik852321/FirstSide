using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
    public class Comment
    {
        public int id { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public DateTime TimeInsert { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int? RestaurantId { get; set; }

        public int? ClubId { get; set; }
    }
}
