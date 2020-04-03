using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPIsEindopdracht_MaximeMinta
{
    public class SongLibrary : DbContext
    {
        public SongLibrary(DbContextOptions<SongLibrary> options): base(options) 
        {
        }

        public  DbSet<Track> Tracks { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
