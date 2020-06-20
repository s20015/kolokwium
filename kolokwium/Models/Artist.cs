using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public String Nickname { get; set; }

        public virtual ICollection<ArtistEvent> ArtistEvent { get; set; }

        public Artist()
        {
            ArtistEvent = new HashSet<ArtistEvent>();
        }

    }
}
