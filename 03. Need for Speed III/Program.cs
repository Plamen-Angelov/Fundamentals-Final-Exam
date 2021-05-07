using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, int> mileage = new Dictionary<string, int>();
            Dictionary<string, int> fuel = new Dictionary<string, int>();

            for (int i = 0; i < num; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split('|');

                string car = carInfo[0];
                int mil = int.Parse(carInfo[1]);
                int carFuel = int.Parse(carInfo[2]);

                mileage.Add(car, mil);
                fuel.Add(car, carFuel);
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Stop")
                {
                    break;
                }

                string car = command[1];

                if (command[0] == "Drive")
                {
                    int distance = int.Parse(command[2]);
                    int fuelNeeded = int.Parse(command[3]);

                    if (fuelNeeded > fuel[car])
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }
                    else
                    {
                        mileage[car] += distance;
                        fuel[car] -= fuelNeeded;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                    }

                    if (mileage[car] >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");

                        mileage.Remove(car);
                        fuel.Remove(car);
                    }
                }
                else if (command[0] == "Refuel")
                {
                    int fuelAdd = int.Parse(command[2]);

                    int remainingFuel = fuel[car];
                    fuel[car] += fuelAdd;

                    if (fuel[car] > 75)
                    {
                        fuel[car] = 75;
                    }

                    Console.WriteLine($"{car} refueled with {fuel[car] - remainingFuel} liters");
                }
                else if (command[0] == "Revert")
                {
                    int kilometers = int.Parse(command[2]);

                    mileage[car] -= kilometers;

                    if (mileage[car] >= 10000)
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                    else
                    {
                        mileage[car] = 10000;
                    }
                }
            }

            foreach (var item in mileage.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value} kms, Fuel in the tank: {fuel[item.Key]} lt.");
            }
        }
    }
}
