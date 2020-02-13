using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstSide.Models;
using FirstSide.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstSide.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //rejestrowanie
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                City=model.City,
                
                
                
            };
          var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                if (_signInManager.IsSignedIn(User)&& User.IsInRole("Admin"))
                    {
                    await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("SignIn");
            }
            
            return View(model);
        }

        //Logowanie
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(RegisterVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
           
            if(user != null)
            {
               var result=await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Nie znaleziono takiego użytkownika");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        

    }
}