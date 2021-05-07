using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex pairsRegex = new Regex(@"([@#])([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1");
            MatchCollection pairs = pairsRegex.Matches(text);
            
            if (pairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine($"No mirror words!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"{pairs.Count} word pairs found!");
            }
            List<string> mirrorPairs = new List<string>();

            foreach (Match item in pairs)
            {
                string first = item.Groups[2].Value;
                string second = item.Groups[3].Value;

                if (string.Concat(first.Reverse()) == second)
                {
                    string newPair = $"{first} <=> {second}";
                    mirrorPairs.Add(newPair);
                }
            }

            if (mirrorPairs.Count == 0)
            {
                Console.WriteLine($"No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine($"{string.Join(", ", mirrorPairs)}");
            }
        }
    }
}
