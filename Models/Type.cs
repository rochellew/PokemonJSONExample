﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONExample.Models
{
    internal class Type
    {
        public string Name { get; set; }

        public Type(string name)
        {
            Name = name;
        }
    }
}
