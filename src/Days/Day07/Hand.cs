using System.Text.RegularExpressions;

namespace AOC2023.Days.Day07;

public class Hand(string cards, int bid) : IComparable<Hand>
{
    private string Cards => cards;
    public int Bid => bid;
    
    public int CompareTo(Hand otherHand) =>
        CalculateHandValue().CompareTo(otherHand.CalculateHandValue());
    
    private int CalculateHandValue()
    {
        string cardsBase14 = cards
            .Replace("A", "E")
            .Replace("K", "D")
            .Replace("Q", "C")
            .Replace("J", "B")
            .Replace("T", "A");
        // Prepend hand type as a letter so get a single integer representing hand value.
        char handType = GetHandType();
        cardsBase14 = handType + cardsBase14;
        // just convert to base 16 since there's a built-in method
        int handValue = Convert.ToInt32(cardsBase14, 16);
        return handValue;
    }

    private char GetHandType()
    {
        int[] duplicatesList = GetArrayDuplicates(this);
        // Need to track pairs and three of a kind until all the way through the duplicates list to make
        // sure there aren't any full houses.
        bool containsPair = false;
        bool containsTwoPair = false;
        bool containsThreeOfAKind = false;
        foreach (int count in duplicatesList)
        {
            switch (count)
            {
                case 5:
                    return (char)HandType.FiveOfAKind;
                case 4:
                    return (char)HandType.FourOfAKind;
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
            return (char)HandType.FullHouse;
        }
        if (containsThreeOfAKind)
        {
            return (char)HandType.ThreeOfAKind;
        }
        if (containsTwoPair)
        {
            return (char)HandType.TwoPair;
        }

        if (containsPair)
        {
            return (char)HandType.Pair;
        }

        return (char)HandType.HighCard;
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
        
    private static int[] GetArrayDuplicates(Hand hand)
    {
        char[] cardTypes = ['2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'];
        int[] count = new int[13];
        for (int i = 0; i < count.Length; i++)
        {
            count[i] = HowManyOfThisCard(hand, cardTypes[i]);
        }
        return count;
    }

    private static int HowManyOfThisCard(Hand hand, char card)
    {
        string regexPattern = "[^" + card + "]*";
        return Regex.Replace(hand.Cards, regexPattern, "").Length;
    }

}