using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Organiser
    {
        public int IdOrganiser { get; set; }
        public String Name { get; set; }

        public virtual ICollection<EventOrganiser> EventOrganiser { get; set; }

        public Organiser()
        {
            EventOrganiser = new HashSet<EventOrganiser>();
        }

    }
}
