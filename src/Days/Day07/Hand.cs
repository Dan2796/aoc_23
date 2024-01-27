using System.Text.RegularExpressions;

namespace AOC2023.Days.Day07;

public class Hand(string cards, int bid)
{
    public string Cards => cards;
    public int CalculateHandValue()
    {
        // convert to base 15 so that equivalent hands can be easily compared by their first letter.
        // Could do in base 14 but would require subtracting one from each number and not much point.
        string cardsBase14 = cards
            .Replace("A", "E")
            .Replace("K", "D")
            .Replace("Q", "C")
            .Replace("J", "B")
            .Replace("T", "A");
        int handValue = Convert.ToInt32(cardsBase14, 15);
        return handValue;
    }

    public HandType GetHandType()
    {
        int[] duplicatesList = GetArrayDuplicates(this);
        HandType handType = HandType.HighCard;
        bool containsThreeOfAKind = false;
        bool containsPair1 = false;
        bool containsPair2 = false;
        foreach(int count in duplicatesList)
        {
            if (count == 5)
            {
                return HandType.FiveOfAKind;
            }

            if (count == 4)
            {
                return HandType.FourOfAKind;
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
            return HandType.FullHouse;
        }
        if (containsThreeOfAKind)
        {
            return HandType.ThreeOfAKind;
        }
        if (containsPair1 && containsPair2)
        {
            return HandType.TwoPair;
        }

        if (containsPair1)
        {
            return HandType.Pair;
        }
        return handType;
    }

    public enum HandType
    {
        FiveOfAKind,
        FourOfAKind,
        FullHouse,
        ThreeOfAKind,
        TwoPair,
        Pair,
        HighCard
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