using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPIsEindopdracht_MaximeMinta
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
                    Title = "Promise",
                    BPM = 110,
                    Year = 2020

                };

                var Artist1 = new Artist()
                {
                    Name = "Polyte",
                    //Tracks = track nog toevoegen, //dia 21
                    ArtistID = 0

                };
                Artist1.Tracks.Add(track); //track toeveogen op deze manier

                //add the book to the collection of books
                context.Artists.Add(Artist1);
                context.Tracks.Add(track);
                context.SaveChanges();
            }
        }
    }
}
