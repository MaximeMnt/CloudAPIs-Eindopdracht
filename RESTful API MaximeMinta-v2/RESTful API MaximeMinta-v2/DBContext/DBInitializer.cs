using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API_MaximeMinta_v2
{
    public class DBInitializer
    {
        public static void Initialize(SongLibraryDbContext context)
        {
            //create if db not exists
            context.Database.EnsureCreated();

            //are there already tracks present
            if (!context.Tracks.Any())
            {
                var track = new Track()
                {
                    Title = "Hello",
                    BPM = 100,
                    Year = 2020,
                    ArtistName = "Kaas",
                    Album = "Welkom API!"
                };

                var track2 = new Track()
                {
                    Title = "I might Delete this one soon",
                    ArtistName = "Polyte",
                    BPM = 140,
                    Year = 2018,
                    Genre = "Trap"
                };

                var Artist = new Artist()
                {
                    Name = "Hey hey hey"
                };
                var Artist1 = new Artist()
                {
                    Name = "Hallow"
                };

                var TrackArtist = new TrackArtist();
                TrackArtist.Artist = Artist;
                TrackArtist.Track = track;


                Artist1.Tracks.Add(track2);
                track2.TrackArtists.Add(TrackArtist);
                context.Tracks.Add(track);
                context.Tracks.Add(track2);
                context.Artists.Add(Artist1);
                context.Artists.Add(Artist);
                context.SaveChanges();
            }
        }
    }
}
