using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, int> hitPoints = new Dictionary<string, int>();
            Dictionary<string, int> manaPoints = new Dictionary<string, int>();

            for (int i = 0; i < num; i++)
            {
                string[] heroes = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                hitPoints.Add(heroes[0], int.Parse(heroes[1]));
                manaPoints.Add(heroes[0], int.Parse(heroes[2]));
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" - ",StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "End")
                {
                    break;
                }

                string name = command[1];

                if (command[0] == "CastSpell")
                {
                    int neededMP = int.Parse(command[2]);
                    string spellName = command[3];

                    if (manaPoints[name] >= neededMP)
                    {
                        manaPoints[name] -= neededMP;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {manaPoints[name]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command[0] == "TakeDamage")
                {
                    int damage = int.Parse(command[2]);
                    string attacker = command[3];

                    hitPoints[name] -= damage;

                    if (hitPoints[name] > 0)
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {hitPoints[name]} HP left!");
                    }
                    else
                    {
                        hitPoints.Remove(name);
                        manaPoints.Remove(name);

                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }
                }
                else if (command[0] == "Recharge")
                {
                    int amount = int.Parse(command[2]);

                    int hadMP = manaPoints[name];
                    manaPoints[name] += amount;

                    if (manaPoints[name] > 200)
                    {
                        manaPoints[name] = 200;
                    }

                    Console.WriteLine($"{name} recharged for {manaPoints[name] - hadMP} MP!");
                }
                else if (command[0] == "Heal")
                {
                    int amount = int.Parse(command[2]);
                    int hadHP = hitPoints[name];
                    hitPoints[name] += amount;

                    if (hitPoints[name] > 100)
                    {
                        hitPoints[name] = 100;
                    }

                    Console.WriteLine($"{name} healed for {hitPoints[name] - hadHP} HP!");
                }
            }
            foreach (var item in hitPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine($" HP: {item.Value}");
                Console.WriteLine($" MP: {manaPoints[item.Key]}");
            }
        }
    }
}
