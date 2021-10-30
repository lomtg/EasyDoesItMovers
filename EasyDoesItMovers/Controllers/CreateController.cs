using EasyDoesItMovers.Helpers;
using EasyDoesItMovers.Models;
using EasyDoesItMovers.Repository;
using EasyDoesItMovers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Controllers
{
    public class CreateController : Controller
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IInformationRepository _informationRepository;

        public CreateController(ITeamRepository teamRepository,
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

        [HttpGet]
        public IActionResult Information()
        {
            return View(_informationRepository.GetInformationPageFromMemory("moving-services"));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamViewModel>>> ShowTeams()
        {
            return View(await _teamRepository.GetTeams());
        }

        [HttpGet]
        public IActionResult Team()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Team(Team team)
        {
            var file = Request.Form.Files.FirstOrDefault();

            var ImageDataIntoBytes = ImageHelpers.TurnImageIntoBytes(file);
            team.ImageData = ImageDataIntoBytes;
            team.Id = Guid.NewGuid();
            _teamRepository.AddTeam(team);
            ViewBag.ImageDataURl = RetrieveImage.GetImageURL(team.ImageData);
            return View(team);
        }

        [HttpGet]
        public IActionResult Testimonial()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamViewModel>>> ShowTestimonials()
        {
            return View(await _testimonialRepository.GetTestimonials());
        }


        [HttpPost]
        public IActionResult Testimonial(Testimonial testimonial)
        {
            var file = Request.Form.Files.FirstOrDefault();

            var ImageDataIntoBytes = ImageHelpers.TurnImageIntoBytes(file);
            testimonial.ImageData = ImageDataIntoBytes;
            testimonial.Id = Guid.NewGuid();
            _testimonialRepository.AddTestimonial(testimonial);
            ViewBag.ImageDataURl = RetrieveImage.GetImageURL(testimonial.ImageData);
            return View();
        }

    }
}
