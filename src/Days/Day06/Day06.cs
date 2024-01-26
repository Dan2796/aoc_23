namespace AOC2023.Days.Day06;
using System.Text.RegularExpressions;

public partial class Day06 : Day<List<Race>, long, Race, long>
{
    protected override int Id => 6;

    protected override List<Race> ParseInputPart1(StreamReader input)
    {
        string raceTimesString = MultipleSpaceRegex().Replace(input.ReadLine(), " ");
        string raceDistancesString = MultipleSpaceRegex().Replace(input.ReadLine(), " ");
        int[] raceTimes = raceTimesString.Split(" ")[1..].Select(int.Parse).ToArray();
        int[] raceDistances = raceDistancesString.Split(" ")[1..].Select(int.Parse).ToArray();
        List<Race> races = [];
        races.AddRange(raceTimes.Select((t, i) => new Race(t, raceDistances[i])));
        return races;
    }

    protected override Race ParseInputPart2(StreamReader input)
    {
        string raceTimeString = MultipleSpaceRegex().Replace(input.ReadLine(), "");
        string raceDistanceString = MultipleSpaceRegex().Replace(input.ReadLine(), "");
        long raceTime = long.Parse(raceTimeString.Replace("Time:", ""));
        long raceDistance= long.Parse(raceDistanceString.Replace("Distance:", ""));
        return new Race(raceTime, raceDistance);
    }

    protected override long SolvePart1(List<Race> races) =>
        races.Aggregate<Race, long>(1, (current, race) => current * race.HowManyWins());

    protected override long SolvePart2(Race race) =>
        race.HowManyWins();
    
    [GeneratedRegex(" +")]
    private static partial Regex MultipleSpaceRegex();
}