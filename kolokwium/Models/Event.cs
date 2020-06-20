using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Event
    {
        public int IdEvent { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<ArtistEvent> ArtistEvent { get; set; }
        public virtual ICollection<EventOrganiser> EventOrganiser { get; set; }

        public Event()
        {
            ArtistEvent = new HashSet<ArtistEvent>();
            EventOrganiser = new HashSet<EventOrganiser>();
        }
    }
}
