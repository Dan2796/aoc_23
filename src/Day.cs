namespace aoc_2023;

public abstract class Day(bool actual)
{
    protected string GetFileName() {
        var dirLocation = actual ? "actual" : "example";
        var dayPrefix = GetDay() < 10 ? "0" : "";
        return "inputs/" + dirLocation + "/day_" + dayPrefix + GetDay() + ".txt";
    }

    protected abstract void ParseInput();
    protected abstract int GetDay();
    protected abstract object GetSolutionPart1();
    protected abstract object GetSolutionPart2();

    public static void PrintSolutions(Day day) {
        day.ParseInput();
        Console.WriteLine("Day " + day.GetDay() + " solution to part 1: " + day.GetSolutionPart1());
        Console.WriteLine("Day " + day.GetDay() + " solution to part 2: " + day.GetSolutionPart2());
    }
}