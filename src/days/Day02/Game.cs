namespace aoc_2023.src.days
{
    public class Game(int id)
    {
        public int id = id;
        readonly List<Show> allShows = [];
        public void AddShow(Show show)
        {
            this.allShows.Add(show);
        }
    }


    public class Show
    {
        private int blue;
        private int red;
        private int green;
        public void SetBlue(int numberBlue)
        {
            this.blue = numberBlue;
        }
        public void SetRed(int numberRed)
        {
            this.red = numberRed;
        }
        public void SetGreen(int numberGreen)
        {
            this.green = numberGreen;
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