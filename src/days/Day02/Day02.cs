using aoc_2023.src.days;

class Day02(Boolean actual) : Day(actual)
{
    public override int GetDay() {
        return 2;
    }
    public override void ParseInput() {
        using StreamReader reader = new(GetFileName());
        while (!reader.EndOfStream)
        {
            string inputLine = reader.ReadLine();
            Game game = new(1);
        }
    }

    public override String GetSolutionPart1() {
        return "tbd";
    }

    public override String GetSolutionPart2() {
        return "tbd";
    }
}
