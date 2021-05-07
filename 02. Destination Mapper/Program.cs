using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();

            Regex findPLaces = new Regex(@"(=|\/)([A-Z][A-Za-z]{2,})\1");
            MatchCollection matches = findPLaces.Matches(places);
            int travelPoints = 0;
            List<string> travelSteps = new List<string>();

            foreach (Match item in matches)
            {
                travelPoints += item.Groups[2].Value.Length;
                travelSteps.Add(item.Groups[2].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", travelSteps)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
