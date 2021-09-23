using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Models
{
    public class CreatureCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at lease one character in this field.")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string DescriptionOfCreature { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at lease one character in this field.")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string CreatureType { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at lease one character in this field.")]
        public string Height { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at lease one character in this field.")]
        public string Weight { get; set; }
        [Required]
        public bool MythicalOrFolktale { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at lease one character in this field.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
    }
}
