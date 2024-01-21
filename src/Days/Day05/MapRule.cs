namespace AOC2023.Days.Day05;

public class MapRule(IReadOnlyList<string> rangeDetails)
{
    private readonly long _destinationStart = long.Parse(rangeDetails[0]);
    private readonly long _rangeStart = long.Parse(rangeDetails[1]);
    private readonly long _rangeLength = long.Parse(rangeDetails[2]);

    public long ApplyRule(long input)
    {
        long output = input > _rangeStart && input < _rangeStart + _rangeLength
            ? input + _destinationStart - _rangeStart
            : input;
        return output;
    }
}
    
