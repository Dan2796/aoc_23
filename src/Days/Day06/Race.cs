public class Race(int _raceTime, int _raceDistance)
{
    public int[] getDistanceOptions()
    {
        int[] options = new int[_raceTime];
        for(int i = 0; i < _raceTime; i++)
        {
            options[i] = getRaceDistance(i, _raceTime);
        }
        return options;
    }

    public static int getRaceDistance(int buttonHoldTime, int raceTime)
    {
        int speed = buttonHoldTime;
        int remainingTime = raceTime - buttonHoldTime;
        return remainingTime * speed;
    }
        
}