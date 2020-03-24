using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace FirstSide.ViewModels
{
    public class EventPartyVM
    {
        public int ClubId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeEnd { get; set; }

        public IFormFile File { get; set;}




    }
}
