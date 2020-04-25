using Microsoft.VisualBasic;
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
    public class Track
    {
        [Key]
        public int TrackID { get; set; } //primaire sleutel
        public string Title { get; set; }
        //public string ArtistName { get; set; } //zou vreemde sleutel moeten zijn
        public string Album { get; set; }
        public string Genre { get; set; }
        //public string FeaturingArtists { get; set; }
        public int Year { get; set; }
        public int BPM { get; set; }
        public string Key { get; set; }
        [JsonIgnore]
        [ForeignKey("ArtistsRef")]
        //[NotMapped]
        public virtual ICollection<Artist> Artists { get; set; } = new Collection<Artist>();
        //public ICollection<TrackArtist> TrackArtists { get; set; }
    }
}
