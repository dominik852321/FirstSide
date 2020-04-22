using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstSide.Interface;
using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstSide.Controllers
{
    public class MenuController : Controller
    {
        private readonly IRestaurantRepository _Repository;

        public MenuController(IRestaurantRepository repo)
        {

            _Repository = repo;

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var restaurant = _Repository.GetRestaurant(id).Result;

            return View(restaurant.Menu);
        }




        [HttpGet]
        public IActionResult AddMenu(int id)
        {
            var restaurant = _Repository.GetRestaurant(id).Result;
            if (restaurant != null)
            {
                var NewMenu = new RestaurantMenu
                {
                    RestaurantId = restaurant.Id,
                    RestaurantName = restaurant.Name
                };
                return View(NewMenu);
            }

            return View("Not Found");
        }

        [HttpPost]
        public IActionResult AddMenu(RestaurantMenu model)
        {
            var restaurant = _Repository.GetRestaurant(model.RestaurantId).Result;

            if (ModelState.IsValid && restaurant != null)
            {
                Menu NewMenu = new Menu
                {
                    Alcohol = model.AlcoholPromotions,
                    Drink = model.DrinkPromotions,
                    Foods = model.FoodPromotions,
                    Pizza = model.PizzaPromotions,
                    Restaurant = restaurant
                };

                _Repository.AddMenu(NewMenu);
                _Repository.UpdateRestaurant(restaurant);

                return RedirectToAction("Details", "Restaurant", new { id = restaurant.Id });
            }
            return View("Model is not valid");
        }


        [HttpGet]
        public IActionResult EditMenu(int id)
        {
            var menu = _Repository.GetMenu(id).Result;
            if (menu != null)
            {
                return View(menu);
            }
            return View("Not Found");
        }

        [HttpPost]
        public IActionResult EditMenu(Menu menu)
        {
            if (ModelState.IsValid)
            {
                _Repository.UpdateMenu(menu);
                return RedirectToAction("Details", "Restaurant", new { id = menu.RestaurantId });
            }

            return View("Model is not valid");
        }
    }
}
