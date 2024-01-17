namespace aoc_2023;

public abstract class Day
{
    protected string GetFileName()
    {
        var dayPrefix = Id < 10 ? "0" : "";
        return "inputs/day_" + dayPrefix + Id + ".txt";
    }

    public abstract int Id { get; }
    public object Part1Solution;
    public object Part2Solution;
    public abstract void ParseInputPart1();
    public abstract void SolvePart1();
    public abstract void ParseInputPart2();
    public abstract void SolvePart2();
}

        
