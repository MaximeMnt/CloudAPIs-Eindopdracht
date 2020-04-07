using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPIsEindopdracht_MaximeMinta
{
    public class DBInitializer
    {
        public static void Initialize(SongLibrary context)
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

                //add the book to the collection of books
                context.Tracks.Add(track);
                context.SaveChanges();
            }
        }
    }
}
