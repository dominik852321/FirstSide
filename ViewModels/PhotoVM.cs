using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.ViewModels
{
    public class PhotoVM
    {
        [Required]
        [MaxLength(50,ErrorMessage ="Name cannot have above 50 characters")]
        public string Name { get; set; }

        public IFormFile PhotoFile { get; set; }
    }
}
