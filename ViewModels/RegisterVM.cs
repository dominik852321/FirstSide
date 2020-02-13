﻿using System.ComponentModel.DataAnnotations;

namespace FirstSide.ViewModels
{
    public class RegisterVM
    {
       

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string City { get; set; }
    }
}
