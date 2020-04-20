using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPIsEindopdracht_MaximeMinta
{
    public class Track
    {
        public int TrackID { get; set; } //primaire sleutel
        public string Title { get; set; }
        public int ArtistID { get; set; } //vreemde sleutel
        public string Album { get; set; }
        public string Genre { get; set; }
        public string FeaturingArtistsIDs { get; set; } //vreemde sleutel
        public int Year { get; set; }
        public int BPM { get; set; }        
        public string Key { get; set; }

        public IList<TrackArtist> TrackArtists { get; set; } = new List<TrackArtist>();
    }
}
