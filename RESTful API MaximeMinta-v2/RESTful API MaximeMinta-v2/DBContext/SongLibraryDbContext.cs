using Microsoft.EntityFrameworkCore;
using RESTful_API_MaximeMinta_v2.Models;
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
        public DbSet<URL> URLs { get; set; }

        public SongLibraryDbContext(DbContextOptions<SongLibraryDbContext> options): base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Voeg een vreemde sleutel toe Tracks.Artists && Artists.Tracks
           //modelBuilder.Entity<Artist>().HasOne(t => t.Name).WithMany(a => a.Tracks).HasForeignKey<Track>(b => b.t)

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrackArtist>()
                .HasKey(t => new { t.ArtistID, t.TrackID });

            modelBuilder.Entity<TrackArtist>()
                .HasOne(t => t.Artist)
                .WithMany(a => a.Tracks)
                .HasForeignKey(t => t.ArtistID);

            modelBuilder.Entity<TrackArtist>()
                .HasOne(t => t.Track)
                .WithMany(a => a.Artists)
                .HasForeignKey(t => t.TrackID);


            //modelBuilder.Entity<Track>().HasKey(t => new { t.TrackID });
            //modelBuilder.Entity<Artist>().HasKey(t => new { t.ArtistID });
        }



    }
}
