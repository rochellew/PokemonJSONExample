using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONExample.Models
{
    internal class Ability
    {
        public string Name { get; set; }

        public Ability(string name)
        {
            Name = name;
        }
    }
}
