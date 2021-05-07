using System;
using System.Linq;
using System.Text;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(">>>");

                if (command[0] == "Generate")
                {
                    break;
                }

                if (command[0] == "Contains")
                {
                    string substring = command[1];

                    if (code.Contains(substring))
                    {
                        Console.WriteLine($"{code} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command[0] == "Flip")
                {
                    string upperrOrLower = command[1];
                    int startIndex = int.Parse(command[2]);
                    int endIndex = int.Parse(command[3]);

                    string substring = code.Substring(startIndex, endIndex - startIndex);
                    string changed = string.Empty;

                    if (upperrOrLower == "Upper")
                    {
                        changed = substring.ToUpper();
                    }
                    else if (upperrOrLower == "Lower")
                    {
                        changed = substring.ToLower();
                    }

                    code = code.Replace(substring, changed);
                    Console.WriteLine(code);
                }
                else if (command[0] == "Slice")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    code = code.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(code);
                }
            }
            Console.WriteLine($"Your activation key is: {code}");
        }
    }
}
