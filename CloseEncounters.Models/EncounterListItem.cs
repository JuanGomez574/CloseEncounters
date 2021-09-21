using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Models
{
    public class EncounterListItem
    {
        public int EncounterId { get; set; }
        public string DescriptionOfEncounter { get; set; }
        public DateTime DateOfEncounter { get; set; }
        public int? CreatureId { get; set; }
        public int? LocationId { get; set; }
    }
}
