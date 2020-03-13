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
        
        public IFormFile Formfile { get; set; }
    }
}
