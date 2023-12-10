namespace aoc_2023.days.Day04;

internal class Day04(bool actual) : Day(actual)
{
    protected override int GetDay() {
        return 4;
    }

    private readonly List<ScratchCard> _allScratchCards = [];
    protected override void ParseInput() { 
        using StreamReader reader = new(GetFileName());
        while (!reader.EndOfStream)
        {
            string inputLine = reader.ReadLine();
            string[] inputLineSplit = inputLine.Split(':');
            ScratchCard scratchCard = new(int.Parse(inputLineSplit[0][5..]));
            string[] inputLineWinnersAndOnCard = inputLineSplit[1].Split("|");
            string[] inputLineWinners = inputLineWinnersAndOnCard[0].Split(" ");
            string[] inputLineOnCard = inputLineWinnersAndOnCard[1].Split(" ");
            foreach (string winner in inputLineWinners)
            {
                if (winner != "")
                {
                  scratchCard.AddWinner(int.Parse(winner));
                }
            }
            foreach (string onCard in inputLineOnCard)
            {
                if (onCard != "")
                { 
                    scratchCard.AddOnCard(int.Parse(onCard));
                }
            }
            _allScratchCards.Add(scratchCard);
        }
    }

    protected override string GetSolutionPart1()
    {
        int totalPoints = 0;
        foreach (ScratchCard card in _allScratchCards)
        {
            totalPoints += card.ScoreCard();
        }
        return totalPoints.ToString();
    }

    protected override string GetSolutionPart2() {
        return "tbd";
    }
}