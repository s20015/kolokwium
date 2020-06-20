using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class ArtistEvent
    {
        public int IdEvent { get; set; }
        public int IdArtist { get; set; }
        public DateTime PerformanceDate { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Event Event { get; set; }


    }
}
