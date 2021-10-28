using EasyDoesItMovers.Models;
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
        [HttpGet]
        public IActionResult Team()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Team(Team team)
        {
            var file = Request.Form.Files.FirstOrDefault();

            //Image img = new Image();
            //img.ImageTitle = file.FileName;

            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            //img.ImageData = ms.ToArray();
            team.ImageData = ms.ToArray();

            ms.Close();
            ms.Dispose();

            //_context.Images.Add(image);
            //_context.SaveChanges();

            //ViewBag.Message = "Image(s) stored in database!";
            //ViewBag.ShortDescription = image.ShortDescription;
            //ViewBag.Text = image.Text;
            //ViewBag.Position = image.Position;
            ViewBag.ImageDataURl = GetImageDataURL(team.ImageData);
            return View(team);
        }

        /*
        [HttpPost]
        public ActionResult RetrieveImage()
        {
            Image img = _context.Images.OrderByDescending
            (i => i.Id).FirstOrDefault();
            string imageBase64Data =
        Convert.ToBase64String(img.ImageData);
            string imageDataURL =
        string.Format("data:image/jpg;base64,{0}",
        imageBase64Data);
            ViewBag.ImageTitle = img.ImageTitle;
            ViewBag.ImageDataUrl = imageDataURL;
            return View("Index", img);
        } */

        public string GetImageDataURL(Byte[] imageData)
        {
            string imageBase64Data =
            Convert.ToBase64String(imageData);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
            return imageDataURL;
        }
    }
}
