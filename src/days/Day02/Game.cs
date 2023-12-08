using System.Reflection.Metadata;

namespace aoc_2023.src.days
{
    public class Game(int __id)
    {
        private readonly int __id = __id;
        readonly List<Show> allShows = [];
        public void AddShow(Show show)
        {
            this.allShows.Add(show);
        }
        public int GetId()
        {
            return __id;
        }
        public bool CheckPossible(int blue, int red, int green)
        {
            foreach (Show show in this.allShows)
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
            foreach (Show show in this.allShows)
            {
                blueMin = show.GetBlue() > blueMin ? show.GetBlue() : blueMin;
                redMin = show.GetRed() > redMin ? show.GetRed() : redMin;
                greenMin = show.GetGreen() > greenMin ? show.GetGreen() : greenMin;

            }
            return blueMin * redMin * greenMin;
        }
    }


    public class Show
    {
        // Starting assumption is there aren't any shown:
        private int blue = 0;
        private int red = 0;
        private int green = 0;
        public void AddColourInfo(int number, string colour) {
            if (colour == "blue") {
                this.blue = number;
            }
            if (colour == "red") {
                this.red = number;
            }
            if (colour == "green") {
                this.green = number;
            }
        }
        public int GetBlue()
        {
            return this.blue;
        }
        public int GetRed()
        {
            return this.red;
        }
        public int GetGreen()
        {
            return this.green;
        }

    }
}