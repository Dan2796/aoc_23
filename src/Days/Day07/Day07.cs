namespace AOC2023.Days.Day07;

public class Day07: Day<List<Hand>, int, List<Hand>, int>

{
    protected override int Id => 7;
    private static List<Hand> ParseInput(StreamReader input, HandFactory handFactory)
    {
        List<Hand> hands = [];
        while (!input.EndOfStream)
        {
            string[] handAndBid = input.ReadLine().Split(" ");
            // Store as base 15 so that comparisons later are easier
            hands.Add(handFactory.CreateHand(handAndBid[0], int.Parse(handAndBid[1])));
        }
        return hands;
    }

    protected override List<Hand> ParseInputPart1(StreamReader input) =>
        ParseInput(input, new JacksHandFactory());

    protected override List<Hand> ParseInputPart2(StreamReader input) =>
        ParseInput(input, new JokersHandFactory());

    private int RankAndSum(List<Hand> hands)
    {
        hands.Sort();
        int answerPart1 = 0;
        int handRank = 1;
        foreach (Hand hand in hands)
        {
            answerPart1 += hand.Bid * handRank;
            handRank++;
        }
        return answerPart1;
    }

    protected override int SolvePart1(List<Hand> hands) =>
        RankAndSum(hands);

    protected override int SolvePart2(List<Hand> hands) =>
        RankAndSum(hands);

}