using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, string[]> pieces = new Dictionary<string, string[]>();

            for (int i = 0; i < num; i++)
            {
                string[] data = Console.ReadLine()
                    .Split('|');

                pieces.Add(data[0], new string[] { data[1], data[2] });
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split('|');

                if (command[0] == "Stop")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    string pieceName = command[1];

                    if (pieces.ContainsKey(pieceName))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                    else
                    {
                        string composer = command[2];
                        string key = command[3];

                        pieces.Add(pieceName, new string[] { composer, key });
                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    string piece = command[1];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else 
                if (command[0] == "ChangeKey")
                {
                    string piece = command[1];
                    string newKey = command[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece][1] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            foreach (var item in pieces.OrderBy(x => x.Key).ThenBy(x => x.Value[1]))
            {
                Console.WriteLine($"{item.Key} -> Composer: { item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
