using FirstSide.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.ViewModels
{
    public class ClubVM
    {
       

        public string Name { get; set; }

        public string City { get; set; }
        
        public string Address { get; set; }
        public IFormFile Photo { get; set; }

        public int Number { get; set; }
    }
}
