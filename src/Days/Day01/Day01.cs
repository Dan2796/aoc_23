namespace aoc_2023.Days.Day01;

class Day01 : Day<int, int>
{

  public override int Id => 1;

  private readonly List<int[]> _calibrationNumbersP1 = [];
  private readonly List<int[]> _calibrationNumbersP2 = [];
    
  private readonly string[] _wordToNumbers = [
    "zero"
    ,"one"
    ,"two"
    ,"three"
    ,"four"
    ,"five"
    ,"six"
    ,"seven"
    ,"eight"
    ,"nine"
  ];

  public override void ParseInputPart1()
  {
    using StreamReader reader = new(GetFileName());
    while (!reader.EndOfStream)
    {
      string? inputLine = reader.ReadLine();
      if (inputLine == null)
      {
        continue;
      }
      DigitsTrackerP1 tracker = new();
      foreach (var t in inputLine)
      {
        // Update both parts if it is a single digit: 
        if (char.IsDigit(t)) {
          tracker.UpdateDigits(t - '0');
        }
      }
      _calibrationNumbersP1.Add([tracker.FirstDigit,
        tracker.SecondDigit]);
    }
  }

  public override void SolvePart1()
  {
    var calibrationSum = 0;
    foreach (var digits in _calibrationNumbersP1)
    {
      calibrationSum += digits[0] * 10;
      calibrationSum += digits[1];
    }
    Part1Solution = calibrationSum;
  }

  public override void ParseInputPart2()
  {
   
    using StreamReader reader = new(GetFileName());
    while (!reader.EndOfStream)
    {
      var inputLine = reader.ReadLine();
      if (inputLine == null)
      {
        continue;
      }
      DigitsTrackerP2 digitsTrackerP2 = new();
      for (var i = 0; i < inputLine.Length; i++)
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
      _calibrationNumbersP2.Add([digitsTrackerP2.FirstDigit,
        digitsTrackerP2.SecondDigit]);
    }
  }

  public override void SolvePart2()
  {
    var calibrationSum = 0;
    foreach (var digits in _calibrationNumbersP2)
    {
      calibrationSum += digits[0] * 10;
      calibrationSum += digits[1];
    }
    Part2Solution = calibrationSum;
  }
}