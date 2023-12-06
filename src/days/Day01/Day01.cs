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
            CalibrationTracker calibrationTracker = new();
            for (int i = 0; i < inputLine.Length; i++)
            {
              if (Char.IsDigit(inputLine[i])) {
                calibrationTracker.UpdateDigits(inputLine[i] - '0');
              }
              if (CalibrationTracker.CheckStringMatch(i, "zero", inputLine)) 
              {
                calibrationTracker.UpdatePart2Digits(0);
              }
              if (CalibrationTracker.CheckStringMatch(i, "one", inputLine))
              {
                calibrationTracker.UpdatePart2Digits(1);
              }
              if (CalibrationTracker.CheckStringMatch(i, "two", inputLine))
              {
                calibrationTracker.UpdatePart2Digits(2);
              }
              if (CalibrationTracker.CheckStringMatch(i, "three", inputLine))
              {
                calibrationTracker.UpdatePart2Digits(3);
              }
              if (CalibrationTracker.CheckStringMatch(i, "four", inputLine))
              {
                calibrationTracker.UpdatePart2Digits(4);
              }
              if (CalibrationTracker.CheckStringMatch(i, "five", inputLine))
              {
                calibrationTracker.UpdatePart2Digits(5);
              }
              if (CalibrationTracker.CheckStringMatch(i, "six", inputLine))
              {
                calibrationTracker.UpdatePart2Digits(6);
              }
              if (CalibrationTracker.CheckStringMatch(i, "seven", inputLine))
              {
                calibrationTracker.UpdatePart2Digits(7);
              }
              if (CalibrationTracker.CheckStringMatch(i, "eight", inputLine))
              {
                calibrationTracker.UpdatePart2Digits(8);
              }
              if (CalibrationTracker.CheckStringMatch(i, "nine", inputLine))
              {
                calibrationTracker.UpdatePart2Digits(9);
              }
            }
            calibrationNumbersP1.Add([calibrationTracker.GetFirstDigitP1(),
                                      calibrationTracker.GetSecondDigitP1()]);
            calibrationNumbersP2.Add([calibrationTracker.GetFirstDigitP2(),
                                      calibrationTracker.GetSecondDigitP2()]);
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
