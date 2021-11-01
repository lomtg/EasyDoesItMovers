using EasyDoesItMovers.Helpers;
using EasyDoesItMovers.Models;
using EasyDoesItMovers.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public AdminController(ITeamRepository teamRepository, ITestimonialRepository testimonialRepository, IInformationRepository informationRepository,IConfiguration configuration )
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

            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _teamRepository = teamRepository;
            _testimonialRepository = testimonialRepository;
            _informationRepository = informationRepository;
            _configuration = configuration;
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
            if (file != null)
            {
                var imageDataIntoBytes = ImageHelpers.TurnImageIntoBytes(file);
                updatingTeam.ImageData = imageDataIntoBytes;
            }

            await _teamRepository.UpdateTeam(id,updatingTeam);
            return View("Team",await _teamRepository.GetTeamsAdmin());
        }

        [HttpGet]
        public IActionResult TestimonialEdit(Guid id)
        {
            return View(_testimonialRepository.GetTestimonialsAdmin().Result.ToList().FirstOrDefault(o => o.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult> TestimonialEdit(Guid id, Testimonial updatingTestimonial)
        {
            var file = Request.Form.Files.FirstOrDefault();
            if(file != null)
            {
            var imageDataIntoBytes = ImageHelpers.TurnImageIntoBytes(file);
            updatingTestimonial.ImageData = imageDataIntoBytes;
            }
            
            await _testimonialRepository.UpdateTestimonial(id, updatingTestimonial);
            return View("Testimonial", await _testimonialRepository.GetTestimonialsAdmin());
        }

        [HttpGet]
        public IActionResult TestimonialAdd()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TeamAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialAdd(Testimonial testimonial)
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (file != null)
            {
                var imageDataIntoBytes = ImageHelpers.TurnImageIntoBytes(file);
                testimonial.ImageData = imageDataIntoBytes;
            }

            await _testimonialRepository.AddTestimonial(testimonial);
            return View("Testimonial", await _testimonialRepository.GetTestimonialsAdmin());
        }

        [HttpPost]
        public async Task<IActionResult> TeamAdd(Team team)
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (file != null)
            {
                var imageDataIntoBytes = ImageHelpers.TurnImageIntoBytes(file);
                team.ImageData = imageDataIntoBytes;
            }

            await _teamRepository.AddTeam(team);
            return View("Team", await _teamRepository.GetTeamsAdmin());
        }

        public async Task<IActionResult> TeamDelete(Guid id)
        {
            await _teamRepository.DeleteTeam(id);
            return View("Team", await _teamRepository.GetTeamsAdmin()); 
        }

        public async Task<IActionResult> TestimonialDelete(Guid id)
        {
            await _testimonialRepository.DeleteTestimonial(id);
            return View("Testimonial", await _testimonialRepository.GetTestimonialsAdmin());
        }

        public async Task<IActionResult> InformationEdit(string slug,Information information)
        {
            var updatedInfo = await _informationRepository.UpdateInformation(slug,information);
            return View("Services", updatedInfo);
        }
    }
}
