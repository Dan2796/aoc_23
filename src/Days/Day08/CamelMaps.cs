namespace AOC2023.Days.Day08;

public class CamelMaps(string lRSequence, Dictionary<string, (string, string)> mappings)
{
    public int FollowMaps()
    {
        string currentPosition = lRSequence[0] == 'L' ? mappings["AAA"].Item1 : mappings["AAA"].Item2;
        // start steps at 1 since first step sis AAA to something, likewise placeInLRSequence
        int numberOfSteps = 1;
        int placeInLrSequence = 1;
        while (currentPosition != "ZZZ")
        {
            currentPosition = lRSequence[placeInLrSequence] == 'L' 
                ? mappings[currentPosition].Item1 
                : mappings[currentPosition].Item2;
            numberOfSteps++;
            placeInLrSequence = placeInLrSequence < lRSequence.Length - 1 ? placeInLrSequence + 1 : 0;
        }
        return numberOfSteps;
    }

    public long FollowAsIfGhost()
    {
        List<string> currentPositions = [];
        currentPositions.AddRange(mappings.Keys.Where(key => key[2] == 'A'));
        int placeInLrSequence = 0;
        long numberOfSteps = 0;
        while (currentPositions.Any(position => position[2] != 'Z'))
        {
            // use for not foreach loop so replacement by index is easy
            for (int i = 0; i < currentPositions.Count; i++)
            {
                currentPositions[i] = lRSequence[placeInLrSequence] == 'L'
                    ? mappings[currentPositions[i]].Item1
                    : mappings[currentPositions[i]].Item2;
            }
            numberOfSteps++;
            placeInLrSequence = placeInLrSequence < lRSequence.Length - 1 ? placeInLrSequence + 1 : 0;
        }
        return numberOfSteps;
    }
}