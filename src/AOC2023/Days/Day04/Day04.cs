namespace AOC2023.Days.Day04;

public class Day04 : Day<List<ScratchCard>, int, List<ScratchCard>, int>
{
    protected override int Id => 4;

    private List<ScratchCard> ParseInput(StreamReader input) { 
        List<ScratchCard> allScratchCards = [];
        while (!input.EndOfStream)
        {
            string inputLine = input.ReadLine();
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
            allScratchCards.Add(scratchCard);
        }

        return allScratchCards;
    }

    protected override List<ScratchCard> ParseInputPart1(StreamReader input) => ParseInput(input);
    protected override List<ScratchCard> ParseInputPart2(StreamReader input) => ParseInput(input);
    protected override int SolvePart1(List<ScratchCard> allScratchCards)
    {
        int totalPoints = allScratchCards.Sum(card => card.ScoreCard());
        return totalPoints;
    }

    protected override int SolvePart2(List<ScratchCard> allScratchCards)
    {
        int[] numberOfEachScratchCard = Enumerable.Repeat(1, allScratchCards.Count).ToArray();  
        foreach (ScratchCard card in allScratchCards)
        {
            int numberOfThisCard = numberOfEachScratchCard[card.GetId() - 1];
            // make sure not to try and update card numbers for cards that don't exist:
            int howManyCardsToDuplicate = card.GetMatchNumber() + card.GetId() - 1 > allScratchCards.Count
                ? allScratchCards.Count - card.GetId() - 1
                : card.GetMatchNumber();
            for (int i = card.GetId(); i < card.GetId() + howManyCardsToDuplicate; i++)
            {
                numberOfEachScratchCard[i] += numberOfThisCard;
            }
        }

        return numberOfEachScratchCard.Sum();
    }
}
