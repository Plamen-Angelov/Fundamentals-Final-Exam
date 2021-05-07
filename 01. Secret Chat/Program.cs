using System;
using System.Linq;
using System.Text;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] command = input
                    .Split(":|:");

                switch (command[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(command[1]);

                        message = message.Insert(index, " ");
                        break;
                    case "Reverse":
                        string substring = command[1];

                        if (message.Contains(substring))
                        {
                            int ind = message.IndexOf(substring);
                            message = message.Remove(ind, substring.Length);

                            StringBuilder sb = new StringBuilder();
                            string reversed = string.Concat(substring.Reverse());
                            sb.Append(message);
                            sb.Append(reversed);
                            message = sb.ToString();
                            //message = message + string.Concat(substring.Reverse());
                        }
                        else
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        break;
                    case "ChangeAll":
                        string substr = command[1];
                        string replacement = command[2];

                        while (message.Contains(substr))
                        {
                            message = message.Replace(substr, replacement);
                        }
                        break;
                }
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
