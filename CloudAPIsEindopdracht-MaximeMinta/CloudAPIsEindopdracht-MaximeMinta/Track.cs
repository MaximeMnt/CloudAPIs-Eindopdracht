using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPIsEindopdracht_MaximeMinta
{
    public class Track
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string FeaturingArtists { get; set; }
        public int Year { get; set; }
        public int BPM { get; set; }        
        public string Key { get; set; }
    }
}
