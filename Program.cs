using System.Text.Json;
using System.Net;
using PokemonJSONExample.Models;
using ConsoleTables;

namespace PokemonJSONExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            // set up path to the JSON file(s)
            var root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            var filePath = root + $"{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}pikachu.json";            
            var dataPath = root + $"{Path.DirectorySeparatorChar}Data";

            // create options JSONSerializer must follow
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var pokedex = new List<Pokemon>();
            foreach(string fileName in Directory.GetFiles(dataPath))
            {
                // set JSON string to empty and set up streamreader based on data file's path
                string jsonString = string.Empty;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    jsonString = sr.ReadToEnd();
                }

                // deserialize (read) JSON and create object(s) based on its information
                var pokemon = JsonSerializer.Deserialize<Pokemon>(jsonString, options);
                pokedex.Add(pokemon);
            }

            // ask the user for a pokemon
            Console.Write("Enter the name of a pokemon: ");
            var pokemonString = Console.ReadLine();
            pokedex.Add(JsonSerializer.Deserialize<Pokemon>(GetPokemonFromAPI(pokemonString), options));


            // sets up a table with a header
            ConsoleTable table = new ConsoleTable("Name", "Types", "Abilities");
            
            // adds rows to the table 
            foreach (var pokemon in pokedex)
            {
                // below will display each pokemon using its ToString() method
                // Console.WriteLine(pokemon + "\n");

                table.AddRow(pokemon.Name, string.Join(", ", pokemon.Types), string.Join(", ", pokemon.Abilities));
            }

            // display the table
            Console.WriteLine(table);
        }

        // sneak peak for MVC
        static string GetPokemonFromAPI(string pokemonName)
        {
            string jsonString = string.Empty;
            var url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}";

            // create web request based on URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using(Stream stream = response.GetResponseStream())
            using(StreamReader sr = new StreamReader (stream))
            {
                jsonString = sr.ReadToEnd();
            }

            return jsonString;
        }
    }
}