using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
    public class Club
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public int Number { get; set; }
        public int PostCode { get; set; }


        public string Description { get; set; }
        public string UserId { get; set; }

        
        public int Visitators { get; set; }

        public string ZdjecieUrl { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<EventClub> EventClubs { get; set; }


    }
}
