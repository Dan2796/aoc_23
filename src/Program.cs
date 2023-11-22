using System;
using System.IO;
using System.Collections;
using System.Security.AccessControl;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
        List<int> calorieNumbers = new List<int>();

        int calorieCounter = 0;
        using (StreamReader reader = new StreamReader("inputs/example/day_1_test.txt"))
        {
            while (!reader.EndOfStream)
            {
                string calorie = reader.ReadLine();
                if (!ObjectSecurity.Equals(calorie, "")) 
                {
                    calorieCounter += Int32.Parse(calorie);
                } else 
                {
                    calorieNumbers.Add(calorieCounter);
                    calorieCounter = 0;
                }
            }
            }
        // add last number in list:
        calorieNumbers.Add(calorieCounter);
        calorieNumbers.Sort();
        calorieNumbers.Reverse();
        Console.WriteLine(calorieNumbers[0]);  // Output the content
        int total = calorieNumbers[0] + calorieNumbers[1] + calorieNumbers[2];
        Console.WriteLine(total);  // Output the content
        }
    }
}