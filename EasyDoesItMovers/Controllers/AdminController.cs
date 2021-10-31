using EasyDoesItMovers.Helpers;
using EasyDoesItMovers.Models;
using EasyDoesItMovers.Repository;
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
        private readonly ITeamRepository _teamRepository;
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IInformationRepository _informationRepository;

        public AdminController(ITeamRepository teamRepository, ITestimonialRepository testimonialRepository, IInformationRepository informationRepository)
        {
            if (teamRepository is null)
            {
                throw new ArgumentNullException(nameof(teamRepository));
            }

            if (testimonialRepository is null)
            {
                throw new ArgumentNullException(nameof(testimonialRepository));
            }

            if (informationRepository is null)
            {
                throw new ArgumentNullException(nameof(informationRepository));
            }

            _teamRepository = teamRepository;
            _testimonialRepository = testimonialRepository;
            _informationRepository = informationRepository;
        }

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

            if (admin.Username != login.Username || admin.Password != admin.Password)
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
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Team(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
            return View(await _teamRepository.GetTeamsAdmin());
            }
            return View(_teamRepository.GetTeamsAdmin().Result.Where(o=> o.Name.ToUpper().Contains(name.ToUpper())));
        }

        [HttpGet]
        public async Task<ActionResult> Testimonial(string name)
        {
            if(String.IsNullOrWhiteSpace(name))
            {
             return View(await _testimonialRepository.GetTestimonialsAdmin());
            }
            return View(_testimonialRepository.GetTestimonialsAdmin().Result.Where(o => o.Name.ToUpper().Contains(name.ToUpper())));
        }

        [HttpGet("Admin/{slug}")]
        public async Task<ActionResult> Services(string slug)
        {
            return View(await _informationRepository.GetInformationPage(slug));
        }

        [HttpGet]
        public IActionResult TeamEdit(Guid id)
        {
            return View(_teamRepository.GetTeamsAdmin().Result.ToList().FirstOrDefault(o=> o.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult> TeamEdit(Guid id,Team updatingTeam)
        {
            var file = Request.Form.Files.FirstOrDefault();
            var imageDataIntoBytes = ImageHelpers.TurnImageIntoBytes(file);
            updatingTeam.ImageData = imageDataIntoBytes;

            await _teamRepository.UpdateTeam(id,updatingTeam);
            return View("Team",_teamRepository.GetTeamsAdmin().Result);
        }

    }
}
