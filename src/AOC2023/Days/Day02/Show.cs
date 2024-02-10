namespace AOC2023.Days.Day02;

public class Show
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