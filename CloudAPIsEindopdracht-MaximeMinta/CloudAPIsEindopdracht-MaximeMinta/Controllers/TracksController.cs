using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudAPIsEindopdracht_MaximeMinta.Controllers
{
    [ApiController]
    [Route("api/tracks")]
    public class TracksController : Controller
    {
        // GET: Toon alle tracks in de bibliotheek
        [HttpGet]
        public Track GetAllTracks()
        {
            var track1 = new Track()
            {
                Title = "I might delete this one soon",
                Album = "",
                Year = 2018,
                BPM = 140,
                Artist = "Polyte",
                Key = "Em"

            };
            //return Content("Hello World!");
            return track1;
        }

        // GET: Tracks/5
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Track> GetTrackById(int id)
        {
            //hier moet dan de logica komen om de track op te zoeken in een lijst/ databank
            if (false) //track not found
            {
                return NotFound();
            }
            return Content(id + " hey wereld!");

        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tracks/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tracks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tracks/Delete/5 -> Delete entry uit db
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //TODO: VERWIJDEREN LOGICA NOG HIER
            return View();
        }

        // POST: Tracks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}