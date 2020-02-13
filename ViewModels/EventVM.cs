using FirstSide.Models;
using Microsoft.AspNetCore.Http;

namespace FirstSide.ViewModels
{
    public class EventVM
    {

        public Event Event { get; set; }
        public Restaurant Restaurant { get; set; }

        public IFormFile File { get; set; }

    }
}
