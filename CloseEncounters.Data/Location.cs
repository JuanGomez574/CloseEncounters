using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Data
{
   public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public int NumberOfEncounters { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [ForeignKey(nameof(Creature))]
        public int CreatureId { get; set; }
        public virtual Creature Creature { get; set; }
        [ForeignKey(nameof(Encounter))]
        public int  EncounterId { get; set; }
        public virtual Encounter Encounter { get; set; }

    }
}
