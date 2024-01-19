namespace AOC2023.days.Day02;

public class Game(int id)
{
    readonly List<Show> allShows = [];
    public void AddShow(Show show)
    {
        allShows.Add(show);
    }
    public int GetId()
    {
        return id;
    }
    public bool CheckPossible(int blue, int red, int green)
    {
        foreach (Show show in allShows)
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
        foreach (Show show in allShows)
        {
            blueMin = show.GetBlue() > blueMin ? show.GetBlue() : blueMin;
            redMin = show.GetRed() > redMin ? show.GetRed() : redMin;
            greenMin = show.GetGreen() > greenMin ? show.GetGreen() : greenMin;

        }
        return blueMin * redMin * greenMin;
    }
}
