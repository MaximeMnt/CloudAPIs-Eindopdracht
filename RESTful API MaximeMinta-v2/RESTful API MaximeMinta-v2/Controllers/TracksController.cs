using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RESTful_API_MaximeMinta_v2
{
    [Route("api/tracks")]
    public class TracksController : Controller
    {
        private readonly SongLibraryDbContext library;

        public TracksController(SongLibraryDbContext library)
        {
            this.library = library;
        }

        [HttpGet] //api/tracks
        public List<Track> GetAllTracks(int? BPM, string Key, string Album, string Title, string Artist, int? page, string sort, int length = 10, string dir = "asc")
        {
            IQueryable<Track> query = library.Tracks;

            if (!string.IsNullOrWhiteSpace(Key))
            {
                query = query.Where(d => d.Key == Key);
            }
            if (BPM != null)
            {
                query = query.Where(d => d.BPM == BPM);
            }
            if (!string.IsNullOrWhiteSpace(Album))
                query = query.Where(d => d.Album == Album);
            if (!string.IsNullOrWhiteSpace(Title))
                query = query.Where(d => d.Title == Title);
            if (page.HasValue)
                query = query.Skip(page.Value * length);
            query = query.Take(length);
            //if (!string.IsNullOrWhiteSpace(Artist))
            //    query = query.Where(d => d.ArtistName == Artist);

            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "BPM":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.BPM);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.BPM);
                        }
                        break;


                    case "Title":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.Title);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.Title);
                        }
                        break;
                }
            }



            return query.ToList();

            //return library.Tracks.ToList();
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
        public IActionResult GetTrackById(int id)
        {
            var track = library.Tracks
                //.Include(d => d.TrackArtists)
                .SingleOrDefault(d => d.TrackID == id);
            
            //var track = library.Tracks.Find(id);
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

        [HttpPut] //change data from db
        public IActionResult UpdateTrack([FromBody] Track UpdateTrack)
        {
            var originalTrack = library.Tracks.Find(UpdateTrack.TrackID);
            if (originalTrack == null)
            {
                return NotFound();
            } 
            else 
            {
                originalTrack.Title = UpdateTrack.Title;
                originalTrack.Album = UpdateTrack.Album;
                //originalTrack.ArtistName = UpdateTrack.ArtistName;
                originalTrack.BPM = UpdateTrack.BPM;
                //originalTrack.FeaturingArtists = UpdateTrack.FeaturingArtists;
                originalTrack.Genre = UpdateTrack.Genre;
                originalTrack.Key = UpdateTrack.Key;
                originalTrack.Year = UpdateTrack.Year;
                //originalTrack.TrackArtists = UpdateTrack.TrackArtists;

                library.SaveChanges();
                return Ok(originalTrack);
            }

        }
    }
}