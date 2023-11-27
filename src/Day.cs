using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

public abstract class Day(Boolean actual)
{
    public String GetFileName() {
        String dirLocation = actual ? "actual" : "example";
        String dayPrefix = this.GetDay() < 10 ? "0" : "";
        return "inputs/" + dirLocation + "/day_" + dayPrefix + this.GetDay() + ".txt";
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