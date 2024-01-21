namespace AOC2023.Days.Day04;

public class ScratchCard(int id)
{
    private readonly HashSet<int> _winners = [];
    private readonly List<int> _onCard = [];

    public int GetId()
    {
        return id;
    }
    public void AddWinner(int winner)
    {
        _winners.Add(winner);
    }

    public void AddOnCard(int numberOnCard)
    {
        _onCard.Add(numberOnCard);
    }

    public int GetMatchNumber()
    {
        return _onCard.Count(number => _winners.Contains(number));
    }

    public int ScoreCard()
        {
            return (int)Math.Pow(2, GetMatchNumber() - 1);
        }
}
