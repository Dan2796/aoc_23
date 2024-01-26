public class Race(int raceTime, int raceDistance)
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
    public int[] GetDistanceOptions()
    {
        int[] options = new int[raceTime];
        for(int i = 0; i < raceTime; i++)
        {
            options[i] = GetRaceDistance(i, raceTime);
        }
        return options;
    }

    public static int GetRaceDistance(int buttonHoldTime, int raceTime)
    {
        int speed = buttonHoldTime;
        int remainingTime = raceTime - buttonHoldTime;
        return remainingTime * speed;
    }
        
}