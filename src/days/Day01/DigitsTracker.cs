using System.Data;

namespace aoc_2023.src.days {
    public class DigitsTracker
    {
        int first_digit_p1;
        int second_digit_p1;
        int first_digit_p2;
        int second_digit_p2;
        bool found_first_digit_p1 = false;
        bool found_first_digit_p2 = false;
        public void CheckStringAndUpdateP2(
            int index,
            string longString,
            string shortString,
            int intEquivalent)
        {
            if (CheckStringMatch(index, shortString, longString))
            {
                this.UpdateDigitsPart2(intEquivalent);

            }

        }
        public void UpdateDigitsBothParts(int new_digit)
        {
            if (!this.found_first_digit_p1)
            {
                first_digit_p1 = new_digit;
                found_first_digit_p1 = true;
            }
            if (!this.found_first_digit_p2)
            {
                first_digit_p2 = new_digit;
                found_first_digit_p2 = true;
            }
            this.second_digit_p1 = new_digit;
            this.second_digit_p2 = new_digit;
        }
        private void UpdateDigitsPart2(int new_digit)
        {
            if (!this.found_first_digit_p2)
            {
                first_digit_p2 = new_digit;
                found_first_digit_p2 = true;
            }
            this.second_digit_p2 = new_digit;
        }
        public int GetFirstDigitP1()
        {
            return this.first_digit_p1;
        }
        public int GetSecondDigitP1()
        {
            return this.second_digit_p1;
        }
        public int GetFirstDigitP2()
        {
            return this.first_digit_p2;
        }
        public int GetSecondDigitP2()
        {
            return this.second_digit_p2;
        }
        public static bool CheckStringMatch(int Index,
                                            string shortString,
                                            string longString)
        {
            if (Index + shortString.Length > longString.Length)
            {
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