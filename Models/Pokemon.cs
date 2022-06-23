using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONExample.Models
{
    internal class Pokemon
    {
        public string Name { get; set; }
        public List<AbilityBase> Abilities { get; set; }
        public List<TypeBase> Types { get; set; }

        public Pokemon(string name, List<AbilityBase> abilities, List<TypeBase> types)
        {
            Name = name;
            Abilities = abilities;
            Types = types;
        }

        public override string ToString()
        {
            string pokemonString = "";
            pokemonString += $"Name: {Name}\n";
            pokemonString += $"Abilities: {string.Join(", ", Abilities)}\n";
            pokemonString += $"Types: {string.Join(", ", Types)}";
            return pokemonString;
        }
    }
}
