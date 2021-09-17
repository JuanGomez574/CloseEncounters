using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Models
{
    public class EncounterCreate
    {       
        [Required]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string DescriptionOfEncounter { get; set; }
        [Required]
        public DateTime DateOfEncounter { get; set; }
        public int CreatureId { get; set; }
        public int LocationId { get; set; }
    }
}
