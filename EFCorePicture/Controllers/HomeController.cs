using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCorePicture.Models;
using EFCorePicture.Data;
using Microsoft.Extensions.Configuration;

namespace EFCorePicture.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;
        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        public IActionResult Index()
        {
            PictureRepository pictureRepository = new PictureRepository(_connectionString);
            List<Picture> pictures = pictureRepository.GetPictures();
            return View(pictures);
        }
        public IActionResult Picture(int Id)
        {
            PictureRepository pictureRepository = new PictureRepository(_connectionString);
            Picture p = pictureRepository.GetPictureById(Id);
            return View(p);
        }
        public IActionResult AddLikes(int Id)
        {
            if (Request.Cookies[$"Likes{Id}"] == null)
            {
                Response.Cookies.Append($"Likes{Id}", Id.ToString());
                PictureRepository pictureRepository = new PictureRepository(_connectionString);
                pictureRepository.AddLike(Id);
                Id id = new Id();
                id.number = Id;
                return Json(id);
            }
            else
            {
                Id id = new Id();
                id.number = Id;
                return Json(id);
            }

        }
        public IActionResult GetLikes(int Id)
        {
            Likes l = new Likes();
            PictureRepository picture = new PictureRepository(_connectionString);
            l.number = picture.GetLikesCount(Id);
            return Json(l);
        }
        public class Id
        {
            public int number { get; set; }
        }
        public class Likes
        {
            public int number { get; set; }
        }
        [HttpGet]
        public IActionResult AddPicture()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPicture(Picture p)
        {
            PictureRepository picture = new PictureRepository(_connectionString);
            picture.AddPicture(p);
            return Redirect("/Home/Index");
        }
    }
}
