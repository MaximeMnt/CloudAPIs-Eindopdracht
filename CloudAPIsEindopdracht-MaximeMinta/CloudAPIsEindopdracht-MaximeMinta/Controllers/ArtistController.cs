using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CloudAPIsEindopdracht_MaximeMinta.Controllers
{
    public class ArtistController : Controller
    {
        private readonly SongLibrary library;

        public IActionResult Index()
        {
            return View();
        }
    }
}