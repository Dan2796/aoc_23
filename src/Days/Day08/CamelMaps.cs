public class CamelMaps(string lRSequence, Dictionary<string, (string, string)> mappings)
{
    public int followMaps()
    {
        string currentPosition = lRSequence[0] == 'L' ? mappings["AAA"].Item1 : mappings["AAA"].Item2;
        // start steps at 1 since first step sis AAA to something, likewise placeInLRSequence
        int numberOfSteps = 1;
        int placeInLRSequence = 1;
        while (currentPosition != "ZZZ")
        {
            currentPosition = lRSequence[placeInLRSequence] == 'L' 
                ? mappings[currentPosition].Item1 
                : mappings[currentPosition].Item2;
            numberOfSteps++;
            placeInLRSequence = placeInLRSequence < lRSequence.Length - 1 ? placeInLRSequence + 1 : 0;
        }
        return numberOfSteps;
    }
    
}