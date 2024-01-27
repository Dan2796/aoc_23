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
        char handType = (char) HandType.HighCard;
        bool containsThreeOfAKind = false;
        bool containsPair1 = false;
        bool containsPair2 = false;
        foreach(int count in duplicatesList)
        {
            if (count == 5)
            {
                return (char) HandType.FiveOfAKind;
            }

            if (count == 4)
            {
                return (char) HandType.FourOfAKind;
            }

            if (count == 3)
            {
                containsThreeOfAKind = true;
            }

            if (count == 2)
            {
                if (containsPair1)
                {
                    containsPair2 = true;
                }
                containsPair1 = true;
            }
        }

        if (containsThreeOfAKind && containsPair1)
        {
            return (char) HandType.FullHouse;
        }
        if (containsThreeOfAKind)
        {
            return (char) HandType.ThreeOfAKind;
        }
        if (containsPair1 && containsPair2)
        {
            return (char) HandType.TwoPair;
        }

        if (containsPair1)
        {
            return (char) HandType.Pair;
        }
        return handType;
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