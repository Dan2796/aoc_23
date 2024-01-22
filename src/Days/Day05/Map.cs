namespace AOC2023.Days.Day05;

public class Map(string sourceName, string destinationName, List<MapRule> mapRules)
{
    public string sourceName = sourceName;
    public string destinationName = destinationName;
    public long MapInput(long input)
    {
        foreach (MapRule mapRule in mapRules)
        {
            long output = mapRule.ApplyRule(input);
            if (output != input)
            {
                return output;
            }
        }
        return input;
    }
}