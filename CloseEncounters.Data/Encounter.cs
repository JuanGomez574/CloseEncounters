using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof (Creature))]
        public int? CreatureId { get; set; }
        public virtual Creature Creature { get; set; }
        [ForeignKey(nameof(Location))]
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int NumberOfEncounters { get; set; }
    }
}
