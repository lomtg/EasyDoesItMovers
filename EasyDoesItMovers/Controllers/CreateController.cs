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

        public CreateController(ITeamRepository teamRepository)
        {
            if (teamRepository is null)
            {
                throw new ArgumentNullException(nameof(teamRepository));
            }

            _teamRepository = teamRepository;
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
            ViewBag.ImageDataURl = GetImageDataURL(team.ImageData);
            return View(team);
        }

        public string GetImageDataURL(Byte[] imageData)
        {
            string imageBase64Data =
            Convert.ToBase64String(imageData);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
            return imageDataURL;
        }
    }
}
