namespace AOC2023.Days.Day07;

public class JokersHandFactory: HandFactory
{
    public override Hand CreateHand(string cards, int bid)
    {
        return new JokersHand(cards, bid);
    }
}