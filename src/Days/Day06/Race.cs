public class Race(long raceTime, long raceDistance)
{
    public int HowManyWins()
    {
        int wins = 0;
        foreach(int distance in GetDistanceOptions())
        {
            if (distance > raceDistance)
            {
                wins++;
            }
        }
        return wins;
    }
    public long[] GetDistanceOptions()
    {
        long[] options = new long[raceTime];
        for(int i = 0; i < raceTime; i++)
        {
            options[i] = GetRaceDistance(i, raceTime);
        }
        return options;
    }

    public static long GetRaceDistance(int buttonHoldTime, long raceTime)
    {
        int speed = buttonHoldTime;
        long remainingTime = raceTime - buttonHoldTime;
        return remainingTime * speed;
    }

    public long HowManyWinsAlternate()
    {
        (float, float) boundaries = QuadraticEquation(raceTime, raceDistance);
        // Add 1 and round down for cases where there is a button press that would end in a draw (i.e. where
        // the equation solves to an integer).
        int lower = (int)Math.Floor(boundaries.Item1 + 1);
        int upper = (int)Math.Ceiling(boundaries.Item2 - 1);
        return 1 + upper - lower;
    }

    public static (float, float) QuadraticEquation(long t, long d)
    {
        float lower = (float)((t - Math.Sqrt(t * t - 4 * d)) / 2);
        float upper = (float)((t + Math.Sqrt(t * t - 4 * d)) / 2);
        return (lower, upper);
    }
}