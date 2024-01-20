using AOC2023.Days.Day01;

namespace AOC2023;

internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            int dayRequested = int.Parse(args[0]);
            RunDay(dayRequested);
        }
        catch (Exception)
        {
            Console.WriteLine("Please supply the number of the day you wish to access, between 1 and 25.");
        }
    }
    private static void RunDay(int dayRequested)
    {
        switch (dayRequested)
        {
            case < 1 or > 25:
                Console.WriteLine("Please supply a valid AOC day, from between 1 and 25.");
                return;
            case 1:
                Day<List<int[]>, int, List<int[]>, int> day = new Day01();
                day.CompletePart1("Inputs/Day01.txt");
                day.CompletePart2("Inputs/Day01.txt");
                break;
            default:
                Console.WriteLine("Sorry, I haven't yet completed day " + dayRequested);
                return;
        }
    }
}
