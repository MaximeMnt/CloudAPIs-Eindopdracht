using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CloudAPIsEindopdracht_MaximeMinta.Controllers
{
    [Route("api/tracks")]
    public class Tracks2Controller : Controller
    {
        private readonly SongLibrary library;

        public Tracks2Controller(SongLibrary library)
        {
            this.library = library;
        }

        [HttpGet] //api/tracks
        public List<Track> GetAllTracks()
        {
            return library.Tracks.ToList();
        }

        [HttpPost]
        public IActionResult CreateTrack([FromBody] Track newTrack)
        {
            //Track toevoegen
            library.Tracks.Add(newTrack);
            library.SaveChanges(); //opslaan
            return Created("", newTrack); //stuur een result 201 terug met het boek als content
        }


        [Route("{id}")]
        [HttpGet]
        public IActionResult GetTrack(int id)
        {
            var track = library.Tracks.Find(id);
            if (track == null)
            {
                return NotFound();
            } return Ok(track);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteTrack(int id)
        {
            var track = library.Tracks.Find(id);
            if (track == null)
            {
                return NotFound();
            } else
            {
                //verwijder boek
                library.Tracks.Remove(track);
                library.SaveChanges();

                return NoContent(); // = de standaard response (204) bij een gelukte delete
            }
        }

        [HttpPut]
        public IActionResult UpdateTrack([FromBody] Track UpdateTrack)
        {
            var originalTrack = library.Tracks.Find(UpdateTrack.ID);
            if (originalTrack == null)
            {
                return NotFound();
            } 
            else 
            {
                originalTrack.Title = UpdateTrack.Title;
                originalTrack.Album = UpdateTrack.Album;
                originalTrack.ArtistID = UpdateTrack.ArtistID;
                originalTrack.BPM = UpdateTrack.BPM;
                originalTrack.FeaturingArtists = UpdateTrack.FeaturingArtists;
                originalTrack.Genre = UpdateTrack.Genre;
                originalTrack.Key = UpdateTrack.Key;
                originalTrack.Year = UpdateTrack.Year;

                library.SaveChanges();
                return Ok(originalTrack);
            }

        }
    }
}