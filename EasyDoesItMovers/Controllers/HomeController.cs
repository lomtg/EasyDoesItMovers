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

        public HomeController(ITeamRepository teamRepository)
        {
            if (teamRepository is null)
            {
                throw new ArgumentNullException(nameof(teamRepository));
            }

            _teamRepository = teamRepository;
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
        public IActionResult Testimonials()
        {
            return View();
        }
    }
}
