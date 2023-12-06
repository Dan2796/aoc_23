namespace aoc_2023.src.days
{
    public class Day01ExtraMethods
    {
        public static bool CheckStringMatch(int Index,
                                            string shortString,
                                            string longString)
        {
            if (Index + shortString.Length > longString.Length) {
                return false;
            }
            if (shortString == longString.Substring(Index, shortString.Length))
            {
                return true;
            }
            return false;
        }
    }
}
