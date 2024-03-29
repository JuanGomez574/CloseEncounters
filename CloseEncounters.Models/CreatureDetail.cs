﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseEncounters.Models
{
    public class CreatureDetail
    {
        public int CreatureId { get; set; }
        public string DescriptionOfCreature { get; set; }
        public string CreatureType { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public bool MythicalOrFolktale { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
    }
}
