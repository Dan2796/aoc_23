namespace AOC2023.Days.Day07;

public abstract class HandFactory
{
    public abstract Hand CreateHand(string cards, int bid);
}

public class JacksHandFactory: HandFactory
{
    public override Hand CreateHand(string cards, int bid) =>
        new JacksHand(cards, bid);
}

public class JokersHandFactory: HandFactory
{
    public override Hand CreateHand(string cards, int bid) =>
        new JokersHand(cards, bid);
}
