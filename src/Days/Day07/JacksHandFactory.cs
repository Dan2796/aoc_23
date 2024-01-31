namespace AOC2023.Days.Day07;

public class JacksHandFactory: HandFactory
{
    public override Hand CreateHand(string cards, int bid)
    {
        return new JacksHand(cards, bid);
    }
}