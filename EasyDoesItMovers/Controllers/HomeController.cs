using EasyDoesItMovers.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITestimonialRepository _testimonialRepository;

        public HomeController(ITeamRepository teamRepository
            ,ITestimonialRepository testimonialRepository)
        {
            if (teamRepository is null)
            {
                throw new ArgumentNullException(nameof(teamRepository));
            }

            if (testimonialRepository is null)
            {
                throw new ArgumentNullException(nameof(testimonialRepository));
            }

            _teamRepository = teamRepository;
            _testimonialRepository = testimonialRepository;
        }
    
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
        
        public async Task<ActionResult> Team()
        {
            return View(await _teamRepository.GetTeams());
        }
        public async Task<ActionResult> Testimonials()
        {
            return View(await _testimonialRepository.GetTestimonials());
        }
    }
}
