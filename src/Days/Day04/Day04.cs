/*using System.Diagnostics.CodeAnalysis;
using System.Linq;

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
        int totalPoints = _allScratchCards.Sum(card => card.ScoreCard());
        return totalPoints.ToString();
    }

    protected override string GetSolutionPart2()
    {
        int[] numberOfEachScratchCard = Enumerable.Repeat(1, _allScratchCards.Count).ToArray();  
        foreach (ScratchCard card in _allScratchCards)
        {
            int numberOfThisCard = numberOfEachScratchCard[card.GetId() - 1];
            // make sure not to try and update card numbers for cards that don't exist:
            int howManyCardsToDuplicate = card.GetMatchNumber() + card.GetId() - 1 > _allScratchCards.Count
                ? _allScratchCards.Count - card.GetId() - 1
                : card.GetMatchNumber();
            for (int i = card.GetId(); i < card.GetId() + howManyCardsToDuplicate; i++)
            {
                numberOfEachScratchCard[i] += numberOfThisCard;
            }
        }

        return numberOfEachScratchCard.Sum().ToString();
    }
}*/