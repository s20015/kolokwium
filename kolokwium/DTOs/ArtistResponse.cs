using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.DTOs
{
    public class ArtistResponse
    {
        public int IdArtist { get; set; }
        public String Nickname { get; set; }

        public ICollection<EventResponse> Events { get; set; }
    }
}
