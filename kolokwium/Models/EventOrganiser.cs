using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class EventOrganiser
    {
        public int IdEvent { get; set; }
        public int IdOrganiser { get; set; }

        public virtual Event Event { get; set; }
        public virtual Organiser Organiser { get; set; }


    }
}
