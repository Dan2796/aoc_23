using System;
using System.Linq;

namespace AOC2023.Days.Day05;

public class Almanac(long[] seeds, List<Map> listOfMaps)
{
    private long ConvertSeedToLocation(long seed)
    {
        // note this assumes that the order of map rules is correct, with each one following the one before.
        long location = seed;
        foreach (Map map in listOfMaps)
        {
            location = map.MapInput(location);
        }

        return location;
    }

    public long[] ConvertAllSeeds()
    {
        return seeds.Select(ConvertSeedToLocation).ToArray();
    }
}