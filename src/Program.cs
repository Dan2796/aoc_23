using AOC2023.Days.Day01;
using AOC2023.Days.Day02;
using AOC2023.Days.Day04;

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
                Day<List<(int, int)>, int, List<(int, int)>, int> day01 = new Day01();
                day01.CompletePart1("Inputs/Day01.txt");
                day01.CompletePart2("Inputs/Day01.txt");
                break;
            case 2:
                Day<List<Game>, int, List<Game>, int> day02 = new Day02();
                day02.CompletePart1("Inputs/Day02.txt");
                day02.CompletePart2("Inputs/Day02.txt");
                break;
            case 4:
                Day<List<ScratchCard>, int, List<ScratchCard>, int> day04 = new Day04();
                day04.CompletePart1("Inputs/Day04.txt");
                day04.CompletePart2("Inputs/Day04.txt");
                break;
            default:
                Console.WriteLine("Sorry, I haven't yet completed day " + dayRequested);
                return;
        }
    }
}
