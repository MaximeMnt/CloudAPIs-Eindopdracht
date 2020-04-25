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
                var Artist = new Artist()
                {
                    Name = "Kanye West"
                };
                var Artist1 = new Artist()
                {
                    Name = "K, Le Maestro"
                };

                var track = new Track()
                {
                    Title = "God Is",
                    BPM = 105,
                    Year = 2019,
                    //ArtistName = "Kanye West",
                    Album = "JESUS IS KING",
                    Key = "Db",
                    Genre = "Hip/Hop",
                    Artists = { Artist }

                };

                var track2 = new Track()
                {
                    Title = "START, FORMAT IT!",
                    //ArtistName = "K, Le Maestro",
                    BPM = 109,
                    Year = 2018,
                    Album = "Single",
                    Genre = "Trap",
                    Key= "Bbm",
                    Artists = { Artist1 }
                };

                

                //var TrackArtist = new TrackArtist() { Track = track2, Artist = Artist };
                //context.TrackArtists.Add(TrackArtist);
                track.Artists.Add(Artist);
                track2.Artists.Add(Artist1);
                context.Tracks.Add(track);
                context.Tracks.Add(track2);
                context.Artists.Add(Artist1);
                context.Artists.Add(Artist);
                context.SaveChanges();
            }
        }
    }
}
