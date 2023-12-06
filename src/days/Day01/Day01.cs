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

        string[] wordToNumbers = [
          "zero",
          "one",
          "two",
          "three",
          "four",
          "five",
          "six",
          "seven",
          "eight",
          "nine",
        ];

        using StreamReader reader = new(GetFileName());
        while (!reader.EndOfStream)
        {
            string inputLine = reader.ReadLine();
            if (inputLine == null)
            {
              continue;
            }
            DigitsTracker digitsTracker = new();
            for (int i = 0; i < inputLine.Length; i++)
            {
              // Update both parts if it is a single digit: 
              if (Char.IsDigit(inputLine[i])) {
                digitsTracker.UpdateDigitsBothParts(inputLine[i] - '0');
              }
              // Update just part 2 if there is a number word match:
              for (int j = 0; j < wordToNumbers.Length; j++)
              {
                digitsTracker.CheckStringAndUpdateP2(
                  i,
                  inputLine,
                  wordToNumbers[j],
                  j
                );
              }
            }
            calibrationNumbersP1.Add([digitsTracker.GetFirstDigitP1(),
                                      digitsTracker.GetSecondDigitP1()]);
            calibrationNumbersP2.Add([digitsTracker.GetFirstDigitP2(),
                                      digitsTracker.GetSecondDigitP2()]);
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
