namespace AOC2023.Days.Day06;

public class Race(long raceTime, long raceDistance)
{
    public long HowManyWins()
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