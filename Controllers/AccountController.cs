using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RamenKing.ViewModel;
using Microsoft.AspNetCore.Identity;
using RamenKing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RamenKing.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginvm)
        {
            if(!ModelState.IsValid)
            {
                return View(loginvm);
            }

            var user = await _userManager.FindByEmailAsync(loginvm.EmailAddress);

            if(user == null)
            {
                TempData["Error"] = "Account not exist or passord error. Please try again";
                return View(loginvm);
            }

            var isPasswordValid =  await _userManager.CheckPasswordAsync(user, loginvm.Password);
            if(!isPasswordValid)
            {
                TempData["Error"] = "Account not exist or passord error. Please try again";
                return View(loginvm);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginvm.Password, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("All", "Ramen");
            }

            return View(loginvm);

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("All", "Ramen");
        }


    }
}

