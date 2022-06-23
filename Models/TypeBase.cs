﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONExample.Models
{
    internal class TypeBase
    {
        public Type Type { get; set; }

        public TypeBase(Type type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return Type.Name;
        }
    }
}
