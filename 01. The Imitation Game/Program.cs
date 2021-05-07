using System;
using System.Text;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split('|');

                if (command[0] == "Decode")
                {
                    break;
                }

                if (command[0] == "Move")
                {
                    int num = int.Parse(command[1]);

                    string substring = message.Substring(0, num);
                    message = message.Remove(0, num);
                    message = message + substring;
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string substring = command[2];

                    message = message.Insert(index, substring);
                }
                else if (command[0] == "ChangeAll")
                {
                    string substring = command[1];
                    string replacement = command[2];

                    while (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                    }
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
