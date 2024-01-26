namespace AOC2023.Days.Day06;
using System.Text.RegularExpressions;
public class Day06 : Day<List<Race>, int, List<Race>, int>
{
    protected override int Id => 6;

    private List<Race> ParseInput(StreamReader input)
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

    protected override List<Race> ParseInputPart1(StreamReader input) =>
        ParseInput(input);

    protected override List<Race> ParseInputPart2(StreamReader input) =>
        ParseInput(input);

    protected override int SolvePart1(List<Race> races)
    {
        int answerPart1 = 1;
        foreach (Race race in races)
        {
            answerPart1 *= race.HowManyWins();
        }

        return answerPart1;
    }
    protected override int SolvePart2(List<Race> race) =>
        1;
}