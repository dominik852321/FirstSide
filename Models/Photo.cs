using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Zdjecie { get; set; }
        public int Restaurantid { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
