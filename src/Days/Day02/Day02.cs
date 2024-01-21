namespace AOC2023.Days.Day02;

public class Day02 : Day<List<Game>, int, List<Game>, int>
{
    protected override int Id => 2;

    private List<Game> ParseInput(StreamReader input)
    {
        List<Game> allGames = [];
        while (!input.EndOfStream)
        {
            string inputLine = input.ReadLine()[5..];
            string[] inputLineSplit = inputLine.Split(':');
            Game game = new(int.Parse(inputLineSplit[0]));
            string[] shows = inputLineSplit[1].Split(";");
            foreach (string show in shows)
            {
                string[] ballsShown = show.Split(",");
                Show myShow = new();
                foreach (string ball in ballsShown)
                {
                    // Index from second character to remove prepended space
                    string[] ballNumberAndColour = ball[1..].Split(" ");
                    myShow.AddColourInfo(int.Parse(ballNumberAndColour[0]),
                        ballNumberAndColour[1]);
                }

                game.AddShow(myShow);
            }

            allGames.Add(game);
        }

        return allGames;
    }

    protected override List<Game> ParseInputPart1(StreamReader input)
    {
        return ParseInput(input);
    }
    protected override List<Game> ParseInputPart2(StreamReader input)
    {
        return ParseInput(input);
    }
    protected override int SolvePart1(List<Game> allGames) {
        int possibleIdsSum = 0;
        foreach (Game game in allGames) {
            if (game.CheckPossible(14, 12, 13)) {
                possibleIdsSum += game.GetId();
            }
        }
        return possibleIdsSum;
    }

    protected override int SolvePart2(List<Game> allGames) {
        int powerSum = 0;
        foreach (Game game in allGames) {
            powerSum += game.PowerOfFewestPossibleCubes();
        }
        return powerSum;
    }
}

