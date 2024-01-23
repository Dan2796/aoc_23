namespace AOC2023.Days.Day06;

public class Day06 : Day<List<Race>, int, List<Race>, int>
{
    protected override int Id => 6;

    private List<Race> ParseInput(StreamReader input)
    {
        List<Race> races = [];
        return races;
    }

    protected override List<Race> ParseInputPart1(StreamReader input) =>
        ParseInput(input);

    protected override List<Race> ParseInputPart2(StreamReader input) =>
        ParseInput(input);
    
    protected override int SolvePart1(List<Race> race) =>
        1;
    protected override int SolvePart2(List<Race> race) =>
        1;
}