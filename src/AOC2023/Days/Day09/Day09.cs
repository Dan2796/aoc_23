namespace AOC2023.Days.Day09;

public class Day09: Day<List<List<int>>, int, List<string>, int>
{
    protected override int Id => 9;
    protected override List<List<int>> ParseInputPart1(StreamReader input)
    {
        var sequences = new List<List<int>>();
        while (!input.EndOfStream)
        {
            sequences.Add(input.ReadLine().Split(" ").Select(int.Parse).ToList());
        }
        return sequences;
    }

    protected override int SolvePart1(List<List<int>> input)
    {
        return input.Sum(GetNextInSequence);
    }

    private static int GetNextInSequence(List<int> sequence)
    {
        if (sequence.All(x => x == 0))
        {
            return 0;
        }
        var differences = new List<int>();
        for (int i = 0; i < sequence.Count - 1; i++)
        {
            differences.Add(sequence[i + 1] - sequence[i]);
        }
        return sequence[^1] + GetNextInSequence(differences);
    }

    protected override List<string> ParseInputPart2(StreamReader input)
    {
        throw new NotImplementedException();
    }

    protected override int SolvePart2(List<string> input)
    {
        throw new NotImplementedException();
    }
}