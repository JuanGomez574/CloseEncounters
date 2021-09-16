using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Data
{
    public class Encounter
    {
        [Key]
        public int EncounterId { get; set; }
        [Required]
        public string DescriptionOfEncounter { get; set; }
        [Required]
        public DateTime DateOfEncounter { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public int CreatureId { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
