using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, double> rarity = new Dictionary<string, double>();
            Dictionary<string, List<double>> raitings = new Dictionary<string, List<double>>();

            for (int i = 0; i < num; i++)
            {
                string[] rarityInfo = Console.ReadLine()
                    .Split("<->");

                if (rarity.ContainsKey(rarityInfo[0]))
                {
                    rarity[rarityInfo[0]] = double.Parse(rarityInfo[1]);
                }
                else
                {
                    rarity.Add(rarityInfo[0], double.Parse(rarityInfo[1]));
                    raitings.Add(rarityInfo[0], new List<double>());
                }
            }

            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                string[] command = input
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                if (command.Length != 2)
                {
                    Console.WriteLine("error");
                }

                if (command[0] == "Rate")
                {
                    string[] commandData = command[1]
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    if (commandData.Length != 2)
                    {
                        Console.WriteLine("error");
                    }

                    string plant = commandData[0];
                    double raiting = double.Parse(commandData[1]);

                    if (raitings.ContainsKey(plant))
                    {
                        raitings[plant].Add(raiting);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command[0] == "Update")
                {
                    string[] commandData = command[1]
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    if (commandData.Length != 2)
                    {
                        Console.WriteLine("error");
                    }

                    string plant = commandData[0];
                    double newRarity = double.Parse(commandData[1]);

                    if (rarity.ContainsKey(plant))
                    {
                        rarity[plant] = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command[0] == "Reset")
                {
                    string plant = command[1];

                    if (raitings.ContainsKey(plant))
                    {
                        raitings[plant].RemoveRange(0, raitings[plant].Count);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in rarity
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x =>
                {
                    if (raitings[x.Key].Count == 0)
                    {
                        return 0;
                    }
                
                    return raitings[x.Key].Average();
                }))
            {
                double avgRating = 0;

                if (raitings[item.Key].Count != 0)
                {
                    avgRating = raitings[item.Key].Average();
                }

                Console.WriteLine($"- {item.Key}; Rarity: {item.Value}; Rating: {avgRating:F2}");
            }
        }
    }
}
