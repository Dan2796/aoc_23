namespace AOC2023;

public abstract class Day<TIn1, TOut1, TIn2, TOut2>
{
    protected abstract int Id { get; }
    protected abstract TIn1 ParseInputPart1(string input);
    protected abstract TOut1 SolvePart1(TIn1 input);
    protected abstract TIn2 ParseInputPart2(string input);
    protected abstract TOut2 SolvePart2(TIn2 input);

    private void PrintSolutionP1(TOut1 part1Solution)
    { 
        Console.WriteLine("Day " + Id + " solution to part 1: " + part1Solution);
    }

    private void PrintSolutionP2(TOut2 part2Solution)
    { 
        Console.WriteLine("Day " + Id + " solution to part 2: " + part2Solution);
    }

    public void CompletePart1(string input) =>
        PrintSolutionP1(SolvePart1(ParseInputPart1(input)));
    public void CompletePart2(string input) =>
        PrintSolutionP2(SolvePart2(ParseInputPart2(input)));
}
