namespace AOC2023.Days.Day01;

public class Day01 : Day<List<int[]>, int, List<int[]>, int>
{
  protected override int Id => 1;

  private readonly string[] _wordToNumbers =
  [
    "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
  ];

  protected override List<int[]> ParseInputPart1(StreamReader input)
  {
    List<int[]> calibrationNumbersP1 = [];
    while (!input.EndOfStream)
    {
      string? inputLine = input.ReadLine();
      if (inputLine == null)
      {
        continue;
      }

      DigitsTrackerP1 tracker = new();
      foreach (char t in inputLine)
      {
        // Update both parts if it is a single digit: 
        if (char.IsDigit(t))
        {
          tracker.UpdateDigits(t - '0');
        }
      }

      calibrationNumbersP1.Add([
        tracker.FirstDigit,
        tracker.SecondDigit
      ]);
    }
    return calibrationNumbersP1;
}

  protected override int SolvePart1(List<int[]> parsedInput)
  {
    int calibrationSum = 0;
    foreach (int[] digits in parsedInput)
    {
      calibrationSum += digits[0] * 10;
      calibrationSum += digits[1];
    }
    return calibrationSum;
  }

  protected override List<int[]> ParseInputPart2(StreamReader input)
  {
    List<int[]> calibrationNumbersP2 = [];
    while (!input.EndOfStream)
    {
      string? inputLine = input.ReadLine();
      if (inputLine == null)
      {
        continue;
      }
      DigitsTrackerP2 digitsTrackerP2 = new();
      for (int i = 0; i < inputLine.Length; i++)
      {
        // Update both parts if it is a single digit: 
        if (char.IsDigit(inputLine[i])) {
          digitsTrackerP2.UpdateDigits(inputLine[i] - '0');
        }
        // Update just part 2 if there is a number word match:
        for (int j = 0; j < _wordToNumbers.Length; j++)
        {
          digitsTrackerP2.CheckStringAndUpdate(
            i,
            inputLine,
            _wordToNumbers[j],
            j
          );
        }
      }
      calibrationNumbersP2.Add([digitsTrackerP2.FirstDigit,
        digitsTrackerP2.SecondDigit]);
    }
    return calibrationNumbersP2;
  }

  protected override int SolvePart2(List<int[]> parsedInput)
  {
    int calibrationSum = 0;
    foreach (int[] digits in parsedInput)
    {
      calibrationSum += digits[0] * 10;
      calibrationSum += digits[1];
    }
    return calibrationSum;
  }
}
