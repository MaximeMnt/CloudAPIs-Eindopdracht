using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RESTful_API_MaximeMinta_v2
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; } //primaire sleutel
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [JsonIgnore]
        //[ForeignKey("TracksRef")]
        [NotMapped]
        public ICollection<Track> Tracks { get; set; } = new Collection<Track>();

        //[JsonIgnore]
        //public ICollection<TrackArtist> TrackArtists { get; set; }

    }
    
}
