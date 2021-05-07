using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Food
    {
        public string Name { get; set; }

        public string ExpireDate { get; set; }

        public int Calories { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Food> foods = new List<Food>();

            Regex regex = new Regex(@"(\||#)([A-Za-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d{1,4}|10000)\1");
            MatchCollection foodData = regex.Matches(input);

            int totalCalories = 0;

            foreach (Match item in foodData)
            {
                Food food = new Food();
                {
                    food.Name = item.Groups[2].Value;
                    food.ExpireDate = item.Groups[3].Value;
                    food.Calories = int.Parse(item.Groups[4].Value);
                }

                foods.Add(food);
                totalCalories += int.Parse(item.Groups[4].Value);
            }

            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");

            foreach (var item in foods)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.ExpireDate}, Nutrition: {item.Calories}");
            }
        }
    }
}
