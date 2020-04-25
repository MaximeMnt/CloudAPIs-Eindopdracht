using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RESTful_API_MaximeMinta_v2
{
    [Route("api/artists")]
    public class ArtistController : Controller
    {
        private readonly SongLibraryDbContext library;

        public ArtistController(SongLibraryDbContext library)
        {
            this.library = library;
        }

        [HttpGet] //api/artists
        public List<Artist> GetAllArtists()
        {
            return library.Artists.ToList();
        }

        [HttpPost]
        public IActionResult CreateArtist([FromBody] Artist newArtist)
        {
            library.Artists.Add(newArtist);
            library.SaveChanges();
            return Created("",newArtist);

        }

        [Route("id")]
        [HttpGet]
        public IActionResult GetArtist(int id)
        {
            var Artist = library.Artists.Find(id);
            if (Artist == null)
            {
                return NotFound();
            }
            return Ok(Artist);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteArtist(int id)
        {
            var Artist = library.Artists.Find(id);
            if (Artist == null)
            {
                return NotFound();
            }
            else
            {
                //verwijder Artist
                library.Artists.Remove(Artist);
                library.SaveChanges();

                return NoContent(); // = de standaard response (204) bij een gelukte delete
            }
        }

        [HttpPut]
        public IActionResult UpdateArtist([FromBody] Artist UpdateArtist)
        {
            var OriginalArtist = library.Artists.Find(UpdateArtist.ArtistID);
            if (OriginalArtist == null)
            {
                return NotFound();
            }
            else
            {
                OriginalArtist.Name = UpdateArtist.Name;
                //OriginalArtist.Tracks = UpdateArtist.Tracks;
                //OriginalArtist.TrackArtists = UpdateArtist.TrackArtists;
                library.SaveChanges();
                return Ok(OriginalArtist);
            }

        }

    }
}