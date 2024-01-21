namespace AOC2023.Days.Day05;

/* An almanac is an array of seeds and a list of maps. A map is a list of map rules determining the way
in which a source category becomes a destination category. Each map rule specifies a source range and a change 
to input that is required for seed sin that range.
 */

public class Day05 : Day<Almanac, long, Almanac, int>
{
    protected override int Id => 5;

    private Almanac ParseInput(StreamReader input)
    {
        // Store seeds as first line
        string[] seeds = input.ReadLine().Replace("seeds: ", "").Split(" ");
        // skip empty line after seeds are listed
        input.ReadLine();
        List<Map> listOfMaps = [];
        List<MapRule> mapRules = [];
        while (!input.EndOfStream)
        {
            string nextLine = input.ReadLine();
            string source = null;
            string destination = null;
            if (nextLine == "")
            {
                 // adds the map to the current list of maps (which is added to the Almanac at construction)
                 listOfMaps.Add(new Map(source, destination, mapRules));
                 // reset mapRules
                 mapRules = [];
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

        Almanac almanac = new(seeds.Select(long.Parse).ToArray(), listOfMaps);
        return almanac;
    }

    protected override Almanac ParseInputPart1(StreamReader input) => ParseInput(input);
    protected override Almanac ParseInputPart2(StreamReader input) => ParseInput(input);

    protected override long SolvePart1(Almanac almanac)
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

    protected override int SolvePart2(Almanac almanac)
    {
        return 1;
    }
}