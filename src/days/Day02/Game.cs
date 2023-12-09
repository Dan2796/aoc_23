namespace aoc_2023.days.Day02;

public class DayGame(int id)
{
    readonly List<DayShow> allShows = [];
    public void AddShow(DayShow show)
    {
        allShows.Add(show);
    }
    public int GetId()
    {
        return id;
    }
    public bool CheckPossible(int blue, int red, int green)
    {
        foreach (DayShow show in allShows)
        {
            if (blue < show.GetBlue()
                || red < show.GetRed()
                || green < show.GetGreen())
            {
                return false;
            }
        }
        return true;
    }
    public int PowerOfFewestPossibleCubes()
    {
        int blueMin = 0;
        int redMin = 0;
        int greenMin = 0;
        foreach (DayShow show in allShows)
        {
            blueMin = show.GetBlue() > blueMin ? show.GetBlue() : blueMin;
            redMin = show.GetRed() > redMin ? show.GetRed() : redMin;
            greenMin = show.GetGreen() > greenMin ? show.GetGreen() : greenMin;

        }
        return blueMin * redMin * greenMin;
    }
}


public class DayShow
{
    // Starting assumption is there aren't any shown:
    private int _blue = 0;
    private int _red = 0;
    private int _green = 0;
    public void AddColourInfo(int number, string colour) {
        switch (colour)
        {
            case "blue":
                _blue = number;
                break;
            case "red":
                _red = number;
                break;
            case "green":
                _green = number;
                break;
        }
    }
    public int GetBlue()
    {
        return _blue;
    }
    public int GetRed()
    {
        return _red;
    }
    public int GetGreen()
    {
        return _green;
    }

}