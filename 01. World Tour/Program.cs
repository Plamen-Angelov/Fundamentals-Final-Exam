using System;
using System.Text;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string tour = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] command = input
                    .Split(':');

                switch (command[0])
                {
                    case "Add Stop":
                        int index = int.Parse(command[1]);
                        string substring = command[2];

                        if (index >= 0 && index < tour.Length)
                        {
                            tour = tour.Insert(index, substring);
                        }

                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        if (startIndex >= 0 && startIndex < tour.Length
                            && endIndex>= 0 && endIndex < tour.Length)
                        {
                            tour = tour.Remove(startIndex, endIndex - startIndex + 1);
                        }

                        break;
                    case "Switch":
                        string oldString = command[1];
                        string newString = command[2];

                        int stringIndex = tour.IndexOf(oldString);

                        while (tour.Contains(oldString))
                        {
                            tour = tour.Replace(oldString, newString);
                        }

                        break;
                }
                Console.WriteLine(tour);
                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {tour}");
        }
    }
}
