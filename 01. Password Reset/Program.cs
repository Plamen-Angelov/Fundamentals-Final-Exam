using System;
using System.Text;
using System.Linq;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    break;
                }

                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "TakeOdd")
                {
                    StringBuilder result = new StringBuilder();

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            result.Append(password[i]);
                        }
                    }
                    password = result.ToString();
                    Console.WriteLine(password);
                }
                else if (command[0] == "Cut")
                {
                    int index = int.Parse(command[1]);
                    int lenght = int.Parse(command[2]);

                    password = password.Remove(index, lenght);

                    Console.WriteLine(password);
                }
                else if (command[0] == "Substitute")
                {
                    string substring = command[1];
                    string subtitude = command[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, subtitude);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
