namespace AOC2023.Days.Day05;

/* An almanac is an array of seeds and a list of maps. A map is a list of map rules determining the way
in which a source category becomes a destination category. Each map rule specifies a source range and a change 
to input that is required for seed sin that range.
 */

public class Day05 : Day<Almanac, long, Almanac, long>
{
    protected override int Id => 5;

    private Almanac ParseInputAfterSeeds(long[] seedsArray, StreamReader input)
    {
        List<Map> listOfMaps = [];
        List<MapRule> mapRules = [];
        string source = null;
        string destination = null;
        while (!input.EndOfStream)
        {
            string nextLine = input.ReadLine();
            if (nextLine == "")
            {
                 // adds the map to the current list of maps (which is added to the Almanac at construction)
                 listOfMaps.Add(new Map(source, destination, mapRules));
                 // reset mapRules, source and destination
                 mapRules = [];
                 source = null;
                 destination = null;
            }
            else if (nextLine.Contains("map"))
            {
                string[] listName = nextLine.Split(" ")[0].Split("-");
                source = listName[0];
                destination = listName[2];
            }
            else
            {
                mapRules.Add(new MapRule(nextLine.Split(" ")));
            }
        }
        // add last one once finished reading file:
        listOfMaps.Add(new Map(source, destination, mapRules));

        Almanac almanac = new(seedsArray, listOfMaps);
        return almanac;
    }

    protected override Almanac ParseInputPart1(StreamReader input)
    { 
        string[] seeds = input.ReadLine().Replace("seeds: ", "").Split(" "); 
        long[] seedsArray = seeds.Select(long.Parse).ToArray(); 
        // skip empty line after seeds are listed
        input.ReadLine();
        return ParseInputAfterSeeds(seedsArray, input);
    } 
    
    
    protected override Almanac ParseInputPart2(StreamReader input)
    { 
        string[] seeds = input.ReadLine().Replace("seeds: ", "").Split(" ");
        long[] seedsAsLongs = seeds.Select(long.Parse).ToArray();
        List<long> seedsAsList = [];
        for (int i = 0; i < seedsAsLongs.Length; i+=2)
        {
            for (long j = seedsAsLongs[i]; j < seedsAsLongs[i] + seedsAsLongs[i + 1]; j++)
            {
                seedsAsList.Add(j);
            }
        }
        // skip empty line after seeds are listed
        input.ReadLine();
        return ParseInputAfterSeeds(seedsAsList.ToArray(), input);
    }

    private long GetMinLocation(Almanac almanac)
    {
        long[] locations = almanac.ConvertAllSeeds();
        long minLocation = locations[0];
        foreach (long location in locations)
        {
            if (location < minLocation)
            {
                minLocation = location;
            }
            
        }
        return minLocation;
    }
    protected override long SolvePart1(Almanac almanac) =>
        GetMinLocation(almanac);
    protected override long SolvePart2(Almanac almanac) =>
        GetMinLocation(almanac);
}