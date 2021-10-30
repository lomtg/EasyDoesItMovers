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
        private readonly IInformationRepository _informationRepository;

        public HomeController(ITeamRepository teamRepository,
            ITestimonialRepository testimonialRepository,
            IInformationRepository informationRepository)
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
    
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }

        public async Task<ActionResult> Services()
        {
            return View(await _informationRepository.GetInformationPage("moving-services"));
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
