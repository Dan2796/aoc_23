namespace AOC2023.Days.Day01
{
    public class DigitsTrackerP1
    {
        public int FirstDigit { get; private set;  }
        public int SecondDigit { get; private set; }
        private bool _foundFirstDigit;
        public void UpdateDigits(int newDigit)
                 {
                     if (!_foundFirstDigit)
                     {
                         FirstDigit = newDigit;
                         _foundFirstDigit = true;
                     }
                     SecondDigit = newDigit;
                 }
    }
}
