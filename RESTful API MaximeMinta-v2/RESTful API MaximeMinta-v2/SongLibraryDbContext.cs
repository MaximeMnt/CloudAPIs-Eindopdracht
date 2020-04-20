using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API_MaximeMinta_v2
{
    public class SongLibraryDbContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<TrackArtist> TrackArtists { get; set; }

        public SongLibraryDbContext(DbContextOptions<SongLibraryDbContext> options): base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackArtist>()
                .HasKey(t => new { t.ArtistID, t.TrackID });

            modelBuilder.Entity<Track>().HasKey(t => new { t.TrackID });
            modelBuilder.Entity<Artist>().HasKey(t => new { t.ArtistID });

        }



    }
}
