using EasyDoesItMovers.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Controllers
{
    public class AdminController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return Redirect("Home");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (String.IsNullOrWhiteSpace(login.Username) && String.IsNullOrWhiteSpace(login.Password))
            {
                ViewBag.Error = "Please Enter Credentials";
                return View();
            }

            Admin admin = new Admin();

            if(admin.Username != login.Username || admin.Password != admin.Password)
            {
                ViewBag.Error = "Incorrect Credentials";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "Admin"),
                new Claim(ClaimTypes.Name, "Admin"),
                new Claim(ClaimTypes.Role, "Admin")
             };
            var identity = new ClaimsIdentity(claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

            return Redirect("Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("../Home/Index");
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View("Home");
        }
    }
}
