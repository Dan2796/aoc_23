using System.Globalization;
using System.Security.AccessControl;
using aoc_2023.src.days;

class Day01(Boolean actual) : Day(actual)
{
    public override int GetDay()
    {
        return 1;
    }
    readonly List<int[]> calibrationNumbersP1 = [];
    readonly List<int[]> calibrationNumbersP2 = [];

    public override void ParseInput()
    {

        using StreamReader reader = new(GetFileName());
        // Only need to check if found part 2, since if found part 1 then have 
        // also found part 2 by definition
        while (!reader.EndOfStream)
        {
            string inputLine = reader.ReadLine();
            if (inputLine == null)
            {
              continue;
            }
            // Initialise with zero to avoid bug of assigning to array later
            // after redefining with if statements
            int first_digit_p1 = 0;
            int first_digit_p2 = 0;
            int second_digit_p1 = 0;
            int second_digit_p2 = 0;
            bool found_first_digit_p1= false;
            bool found_first_digit_p2= false;
            // check for digit 1 first by going forwards:
            for (int i = 0; i < inputLine.Length; i++)
            {
              if (Char.IsDigit(inputLine[i]))
              {
                if (!found_first_digit_p1)
                {
                  first_digit_p1 = inputLine[i] - '0';
                  found_first_digit_p1 = true;
                }
                if (!found_first_digit_p2)
                {
                  first_digit_p2 = inputLine[i] - '0';
                  found_first_digit_p2 = true;
                }
                second_digit_p1 = inputLine[i] - '0';
                second_digit_p2 = inputLine[i] - '0';
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "zero", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 0;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 0;
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "one", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 1;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 1;
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "two", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 2;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 2;
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "three", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 3;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 3;
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "four", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 4;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 4;
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "five", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 5;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 5;
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "six", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 6;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 6;
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "seven", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 7;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 7;
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "eight", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 8;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 8;
              }
              if (Day01ExtraMethods.CheckStringMatch(i, "nine", inputLine))
              {
                if (!found_first_digit_p2) {
                  first_digit_p2 = 9;
                  found_first_digit_p2 = true;
                }
                second_digit_p2 = 9;
              }
            }
            calibrationNumbersP1.Add([first_digit_p1, second_digit_p1]);
            calibrationNumbersP2.Add([first_digit_p2, second_digit_p2]);
            Console.WriteLine("Line " + inputLine);
            Console.WriteLine("First: " + first_digit_p2 + " Second: " + second_digit_p2);
        }
    }
    
    public override string GetSolutionPart1()
    {
      int calibrationSum = 0;
      foreach (int[] digits in calibrationNumbersP1)
      {
        calibrationSum += digits[0] * 10;
        calibrationSum += digits[1];
      }
      return calibrationSum.ToString();
    }

    public override String GetSolutionPart2()
    {
      int calibrationSum = 0;
      foreach (int[] digits in calibrationNumbersP2)
      {
        calibrationSum += digits[0] * 10;
        calibrationSum += digits[1];
      }
      return calibrationSum.ToString();
    }
}
