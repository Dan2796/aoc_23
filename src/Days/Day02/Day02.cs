using aoc_2023.src.days;

namespace aoc_2023.days.Day02;

internal class Day02(bool actual) : Day(actual)
{
    protected override int GetDay() {
        return 2;
    }

    private readonly List<Game> _allGames = [];

    protected override void ParseInput() {
        using StreamReader reader = new(GetFileName());
        while (!reader.EndOfStream)
        {
            string inputLine = reader.ReadLine()[5..];
            string[] inputLineSplit = inputLine.Split(':');
            Game game = new(int.Parse(inputLineSplit[0]));
            string[] shows = inputLineSplit[1].Split(";");
            foreach (string show in shows) {
                string[] ballsShown = show.Split(",");
                Show myShow = new();
                foreach (string ball in ballsShown) {
                    // Index from second character to remove prepended space
                    string[] ballNumberAndColour = ball[1..].Split(" ");
                    myShow.AddColourInfo(int.Parse(ballNumberAndColour[0]),
                        ballNumberAndColour[1]);
                }
                game.AddShow(myShow);
            }
            _allGames.Add(game);
        }
    }

    protected override String GetSolutionPart1() {
        int possibleIdsSum = 0;
        foreach (Game game in _allGames) {
            if (game.CheckPossible(14, 12, 13)) {
                possibleIdsSum += game.GetId();
            }
        }
        return possibleIdsSum.ToString();
    }

    protected override String GetSolutionPart2() {
        int powerSum = 0;
        foreach (Game game in _allGames) {
            powerSum += game.PowerOfFewestPossibleCubes();
        }
        return powerSum.ToString();
    }
}