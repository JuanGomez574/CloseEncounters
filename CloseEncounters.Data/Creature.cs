using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Data
{
    public class Creature
    {
        [Key]
        public int CreatureId { get; set; }
        [Required]
        public string DescriptionOfCreature { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [ForeignKey(nameof(Encounter))]
        public int EncounterId { get; set; }
        public virtual Encounter Encounter { get; set; }
        [Required]
        public string CreatureType { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public bool MythicalOrFolktale { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
