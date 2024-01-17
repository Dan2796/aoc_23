using aoc_2023.Days.Day01;

namespace aoc_2023;

internal class Program
{
    public static void Main(string[] args)
    { 
        Day01 day;
        int dayRequested;
        try
        {
            dayRequested = int.Parse(args[0]);
        }
        catch (Exception)
        {
            Console.WriteLine("Please supply the number of the day you wish to access, between 1 and 25.");
            return;
        }

        switch (dayRequested)
        {
            case < 1 or > 25:
                Console.WriteLine("Please supply a valid AOC day, from between 1 and 25.");
                return;
            case 1:
                day = new Day01();
                break;
            default:
                Console.WriteLine("Sorry, I haven't yet completed day " + args[0]);
                return;
        }
        
        day.ParseInputPart1();
        day.SolvePart1();
        Console.WriteLine("Day " + day.Id + " solution to part 1: " + day.Part1Solution);
        day.ParseInputPart2();
        day.SolvePart2();
        Console.WriteLine("Day " + day.Id + " solution to part 2: " + day.Part2Solution);
        }
}