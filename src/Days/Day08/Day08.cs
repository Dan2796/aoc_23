using System.Text.RegularExpressions;

namespace AOC2023.Days.Day08;

public class Day08 : Day<CamelMaps, int, CamelMaps, int>
{
    protected override int Id => 8;

    // only want to keep capital letters, commas and equals sign
    private static readonly Regex irrelevantCharacters = new Regex(@"[^A-Z,=]");
    private static CamelMaps ParseInput(StreamReader input)
    {
        string leftRightSequence = input.ReadLine();
        // skip line which is empty:
        input.ReadLine();
        Dictionary<string, (string, string)> mappings = new();
        while (!input.EndOfStream)
        {
            string[] mapping = irrelevantCharacters
                .Replace(input.ReadLine(),"")
                .Replace("=", ",")
                .Split(",");
            mappings.Add(mapping[0], (mapping[1], mapping[2]));
        }
        CamelMaps camelMaps = new(leftRightSequence, mappings);
        return camelMaps;
    }
    protected override CamelMaps ParseInputPart1(StreamReader input) =>
        ParseInput(input);
    protected override CamelMaps ParseInputPart2(StreamReader input) =>
        ParseInput(input);
    protected override int SolvePart1(CamelMaps camelMaps) => 0;
    protected override int SolvePart2(CamelMaps camelMaps) => 0;
}
