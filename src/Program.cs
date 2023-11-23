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
            Day.PrintSolutions(new Day02(false));
        }
    }
}

public abstract class Day
{
    public Day(Boolean actual)
    {
        String file;
        if (actual) {
            if (this.GetDay() < 10)
            {
                file = "inputs/actual/day_0" + this.GetDay() + ".txt";
            } else
            {
                file = "inputs/actual/day_" + this.GetDay() + ".txt";
            }
        } else 
        {
            if (this.GetDay() < 10)
            {
                file = "inputs/example/day_0" + this.GetDay() + ".txt";
            } else
            {
                file = "inputs/example/day_" + this.GetDay() + ".txt";
            }
        }
    }

    protected Day()
    {
    }

    public abstract void ParseInput();
    public abstract int GetDay();
    public abstract Object GetSolutionPart1();
    public abstract Object GetSolutionPart2();

    public static void PrintSolutions(Day day) {
        day.ParseInput();
        Console.WriteLine("Day " + day.GetDay() + " solution to part 1: " + day.GetSolutionPart1().ToString());
        Console.WriteLine("Day " + day.GetDay() + " solution to part 2: " + day.GetSolutionPart2().ToString());
    }
}

class Day02(Boolean actual) : Day(actual)
{
    public override int GetDay() {
        return 2;
    }
    List<int> calorieNumbers = new List<int>();

    public override void ParseInput() {

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
    }

    public override String GetSolutionPart1() {
        return calorieNumbers[0].ToString();
    }

    public override String GetSolutionPart2() {
        int total = calorieNumbers[0] + calorieNumbers[1] + calorieNumbers[2];
        return total.ToString();
    }
}