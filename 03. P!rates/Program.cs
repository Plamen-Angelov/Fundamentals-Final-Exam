using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> population = new Dictionary<string, int>();
            Dictionary<string, int> gold = new Dictionary<string, int>();
 
            while (input != "Sail")
            {
                string[] cityInfo = input
                    .Split("||");

                string city = cityInfo[0];
                int cityPopulation = int.Parse(cityInfo[1]);
                int cityGold = int.Parse(cityInfo[2]);

                if (population.ContainsKey(city))
                {
                    population[city] += cityPopulation;
                    gold[city] += cityGold;

                }
                else
                {
                    population.Add(city, cityPopulation);
                    gold.Add(city, cityGold);
                }
                input = Console.ReadLine();
            }

            while (true)
            {
                string evenet = Console.ReadLine();

                if (evenet == "End")
                {
                    break;
                }

                string[] parts = evenet
                    .Split("=>");

                if (parts[0] == "Plunder")
                {
                    string city = parts[1];
                    int people = int.Parse(parts[2]);
                    int stolenGold = int.Parse(parts[3]);

                    population[city] -= people;
                    gold[city] -= stolenGold;

                    Console.WriteLine($"{city} plundered! {stolenGold} gold stolen, {people} citizens killed.");

                    if (population[city] == 0 || gold[city] == 0)
                    {
                        Console.WriteLine($"{city} has been wiped off the map!");
                        population.Remove(city);
                        gold.Remove(city);
                    }
                }
                else if (parts[0] == "Prosper")
                {
                    string city = parts[1];
                    int goldIncrease = int.Parse(parts[2]);

                    if (goldIncrease < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    gold[city] += goldIncrease;
                    Console.WriteLine($"{goldIncrease} gold added to the city treasury. {city} now has {gold[city]} gold.");
                }
            }
            if (population.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Dictionary<string, int> sorted = gold
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"Ahoy, Captain! There are {sorted.Count} wealthy settlements to go to:");

                foreach (var item in sorted)
                {
                    Console.WriteLine($"{item.Key} -> Population: {population[item.Key]} citizens, Gold: {item.Value} kg");
                }
            }
        }
    }
}
