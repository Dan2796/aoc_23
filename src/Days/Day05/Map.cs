namespace AOC2023.Days.Day05;

public class Map(string sourceName, string destinationName, List<MapRule> mapRules)
{
    public string sourceName = sourceName;
    public string destinationName = destinationName;
    public long MapInput(long input)
    {
        long output = input;
        foreach (MapRule mapRule in mapRules)
        {
            output = mapRule.ApplyRule(output);
        }

        return output;
    }
}
    
