namespace AOC2023.Days.Day07;

public abstract class Hand: IComparable<Hand>
{
    private readonly string _cards;
    public int Bid { get; }
    private readonly int _handValue;

    protected Hand(string cards, int bid)
    {
        _cards = cards;
        Bid = bid; 
        _handValue = CalculateHandValue();
}
    
    public int CompareTo(Hand otherHand) =>
        _handValue.CompareTo(otherHand._handValue);
    
    private int CalculateHandValue()
    {
        string cardsBase14 = _cards
            .Replace("A", "E")
            .Replace("K", "D")
            .Replace("Q", "C")
            .Replace("J", "B")
            .Replace("T", "A");
        // Prepend hand type as a letter so get a single integer representing hand value.
        char handType = (char)AssignHandType();
        cardsBase14 = handType + cardsBase14;
        // just convert to base 16 since there's a built-in method
        int handValue = Convert.ToInt32(cardsBase14, 16);
        return handValue;
    }

    private HandType AssignHandType() =>
        CheckMaxHandType(CountCards());

    private static HandType CheckMaxHandType(Dictionary<char, int> countedCards)
    {
        // Need to track pairs and three of a kind until all the way through the duplicates list to make
        // sure there aren't any full houses.
        bool containsPair = false;
        bool containsTwoPair = false;
        bool containsThreeOfAKind = false;
        foreach(int count in countedCards.Values)
        {
            switch (count)
            {
                case 5:
                    return HandType.FiveOfAKind;
                case 4:
                    return HandType.FourOfAKind;
                case 3:
                    containsThreeOfAKind = true;
                    break;
                case 2:
                    if (containsPair)
                    {
                        containsTwoPair = true;
                    }
                    containsPair = true;
                    break;
            }
        }
        if (containsPair && containsThreeOfAKind)
        {
            return HandType.FullHouse;
        }
        if (containsThreeOfAKind)
        {
            return HandType.ThreeOfAKind;
        }
        if (containsTwoPair)
        {
            return HandType.TwoPair;
        }

        if (containsPair)
        {
            return HandType.Pair;
        }

        return HandType.HighCard;
    }

    private enum HandType
    {
        FiveOfAKind = '7',
        FourOfAKind = '6',
        FullHouse = '5',
        ThreeOfAKind = '4',
        TwoPair = '3',
        Pair = '2',
        HighCard = '1'
    }
        
    private Dictionary<char, int> CountCards()
    {
        var countedCards = new Dictionary<char, int>
        {
            { '2', 0 },
            { '3', 0 },
            { '4', 0 },
            { '5', 0 },
            { '6', 0 },
            { '7', 0 },
            { '8', 0 },
            { '9', 0 },
            { 'T', 0 },
            { 'J', 0 },
            { 'Q', 0 },
            { 'K', 0 },
            { 'A', 0 }
        };
        foreach (char card in _cards)
        {
            countedCards[card]++;
        }
        return countedCards;
    }
}