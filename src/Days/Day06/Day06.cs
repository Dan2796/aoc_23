namespace AOC2023.Days.Day06;
using System.Text.RegularExpressions;
public class Day06 : Day<List<Race>, int, Race, long>
{
    protected override int Id => 6;

    protected override List<Race> ParseInputPart1(StreamReader input)
    {
        string raceTimesString = Regex.Replace(input.ReadLine(), "  +", " ");
        string raceDistancesString = Regex.Replace(input.ReadLine(), "  +", " ");
        int[] raceTimes = raceTimesString.Split(" ")[1..].Select(int.Parse).ToArray();
        int[] raceDistances = raceDistancesString.Split(" ")[1..].Select(int.Parse).ToArray();

        List<Race> races = [];
        for (int i = 0; i < raceTimes.Length; i++)
        {
            races.Add(new Race(raceTimes[i], raceDistances[i]));
        }
        return races;
    }

    protected override Race ParseInputPart2(StreamReader input)
    {
        string raceTimeString = Regex.Replace(input.ReadLine(), " +", "");
        string raceDistanceString = Regex.Replace(input.ReadLine(), " +", "");
        long raceTime = long.Parse(raceTimeString.Replace("Time:", ""));
        long raceDistance= long.Parse(raceDistanceString.Replace("Distance:", ""));
        return new Race(raceTime, raceDistance);
    }

    protected override int SolvePart1(List<Race> races)
    {
        int answerPart1 = 1;
        foreach (Race race in races)
        {
            answerPart1 *= race.HowManyWins();
        }

        return answerPart1;
    }

    protected override long SolvePart2(Race race)
    {
        return race.HowManyWinsAlternate();
    }
}