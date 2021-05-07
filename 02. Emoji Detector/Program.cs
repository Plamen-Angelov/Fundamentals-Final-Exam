using System;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex digitRegex = new Regex(@"\d");
            MatchCollection digits = digitRegex.Matches(input);

            long threshold = 1;

            foreach (Match digit in digits)
            {
                threshold *= int.Parse(digit.Value);
            }

            Regex emojiRegex = new Regex(@"([*:]{2})([A-Z][a-z]{2,})\1");
            MatchCollection emojis = emojiRegex.Matches(input);

            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            foreach (Match item in emojis)
            {
                int coolnes = 0;

                string emoji = item.Groups[2].Value;

                foreach (char ch in emoji)
                {
                    coolnes += ch;
                }

                if (coolnes > threshold)
                {
                    Console.WriteLine($"{item.Value}");

                }
            }        
        }
    }
}
