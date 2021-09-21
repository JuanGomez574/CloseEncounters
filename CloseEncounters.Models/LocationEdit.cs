using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Models
{
    public class LocationEdit
    {
        public int LocationId { get; set; }
        public int NumberOfEncounters { get; set; }
        public int CreatureId { get; set; }
        public int EncounterId { get; set; }
        
    }
}
