using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Models
{
    public class LocationCreate
    {
        [Required]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        
      public int NumberOfEncounters { get; set; }
       public int CreatureId { get; set; }
       public int EncounterId { get; set; }
       public int LocationId { get; set; }
    }
}

