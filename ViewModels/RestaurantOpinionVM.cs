using FirstSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.ViewModels
{
    public class RestaurantOpinionVM
    {
        public Restaurant Restaurant { get; set; }

       public CommentVM CommentVM { get; set; }
    }
}
