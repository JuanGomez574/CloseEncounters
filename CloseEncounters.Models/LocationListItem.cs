﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Models
{
    public class LocationListItem
    {
        public int LocationId { get; set; }
        public int NumberOfEncounters { get; set; }
        public string LocationName { get; set; }
        public Guid AuthorId { get; set; }
    }
}
