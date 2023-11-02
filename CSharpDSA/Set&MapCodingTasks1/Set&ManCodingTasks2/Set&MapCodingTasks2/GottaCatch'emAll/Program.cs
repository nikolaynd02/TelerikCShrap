using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GottaCatch_emAll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Pokemon> pokemonsPositions = new Dictionary<int, Pokemon>();
            Dictionary<string, HashSet<Pokemon>> typeOfPokemons = new Dictionary<string, HashSet<Pokemon>>();


            string input = string.Empty;

            StringBuilder output = new StringBuilder();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] commandParams = input.Split(' ').ToArray();

                string cmdType = commandParams[0];

                if (cmdType == "add")
                {
                    string name = commandParams[1];
                    string type = commandParams[2];
                    int power = int.Parse(commandParams[3]);
                    int position = int.Parse(commandParams[4]);

                    Pokemon pokemon = new Pokemon(name, type, power);

                    if (!pokemonsPositions.ContainsKey(position - 1))
                    {
                        pokemonsPositions.Add(position - 1, pokemon);
                    }
                    else
                    {
                        //Pokemon temp = null;
                        //bool switched = false;
                        for(int i = pokemonsPositions.Count; i >= 0; i--)
                        {
                            if(i > position - 1)
                            {
                                pokemonsPositions[i] = pokemonsPositions[i - 1];
                            }
                            if(i == position - 1)
                            {
                                pokemonsPositions[i] = pokemon;
                                continue;
                            }
                           

                        }
                    }

                    if (!typeOfPokemons.ContainsKey(type))
                    {
                        typeOfPokemons.Add(type, new HashSet<Pokemon>());
                    }

                    typeOfPokemons[type].Add(pokemon);

                    output.AppendLine($"Added pokemon {name} to position {position}");

                }
                else if (cmdType == "find")
                {
                    string targetType = commandParams[1];

                    if (!typeOfPokemons.ContainsKey(targetType))
                    {
                        output.AppendLine($"Type {targetType}: ");
                        continue;
                    }

                    var targetPokemons = typeOfPokemons[targetType].OrderBy(p => p.Name).ThenByDescending(p => p.Power).Take(5);

                    output.Append($"Type {targetType}:");

                    if(targetPokemons.Count() == 0)
                    {
                        output.AppendLine();
                        
                    }

                    foreach( var targetPokemon in targetPokemons )
                    {
                        output.Append($" {targetPokemon.ToString()};");
                    }
                    if(targetPokemons.Count() != 0)
                    {
                        output.Remove(output.Length - 1, 1 );
                    }
                    output.AppendLine();

                }
                else if(cmdType == "ranklist")
                {
                    int start = int.Parse(commandParams[1]);
                    int end = int.Parse(commandParams[2]);


                    for(int i = start - 1; i <= end - 1; i++)
                    {
                        output.Append($"{i + 1}. {pokemonsPositions[i].ToString()}; ");
                    }
                    output.Remove(output.Length - 2, 2);
                    output.AppendLine();
                }

            }

            Console.WriteLine(output.ToString());
            ;
        }
    }

    internal class Pokemon
    {
        public Pokemon(string name, string type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Pokemon pokemon && Name == pokemon.Name && Type == pokemon.Type && Power == pokemon.Power ;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Type.GetHashCode() + Power.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}({Power})";
        }
    }
}