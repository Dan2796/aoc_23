namespace aoc_2023.days.Day04;

public class ScratchCard(int id)
{
    readonly HashSet<int> _winners = [];
    readonly List<int> _onCard = [];

    public void AddWinner(int winner)
    {
        _winners.Add(winner);
    }
    public void AddOnCard(int numberOnCard)
    {
        _onCard.Add(numberOnCard);
    }

    public int ScoreCard()
    {
        int howManyMatched = 0;
        foreach (int number in _onCard)
        {
            if (_winners.Contains(number))
            {
                howManyMatched++;
            }
        }
        return (int)Math.Pow(2, howManyMatched - 1);
    }
}