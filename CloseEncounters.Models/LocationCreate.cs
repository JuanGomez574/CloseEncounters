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
        public int NumberOfEncounters { get; set; }
       public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}

