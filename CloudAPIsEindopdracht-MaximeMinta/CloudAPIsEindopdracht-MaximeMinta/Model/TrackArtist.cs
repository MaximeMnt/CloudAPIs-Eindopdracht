using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPIsEindopdracht_MaximeMinta
{
    public class TrackArtist
    {
        public int TrackID { get; set; }
        public Track Track { get; set; }

        public int ArtistID { get; set; }
        public Artist Artist { get; set; }

    }
}
