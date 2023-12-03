using System.Security.AccessControl;

class Day01(Boolean actual) : Day(actual)
{
    public override int GetDay() {
        return 1;
    }
    List<string> input = new List<string>();
    List<List<int>> inputDigits = new List<List<int>>();

    public override void ParseInput() {

        using (StreamReader reader = new StreamReader(GetFileName()))
        { 
            while (!reader.EndOfStream)
            {
              string inputLine = reader.ReadLine();
              input.Add(inputLine);
              List<int> justDigits = new List<int>();
              foreach (char c in inputLine)
              {
                if (Char.IsDigit(c))
                {
                  int charAsDigit = c - '0';
                  justDigits.Add(charAsDigit);
                }
              }
              inputDigits.Add(justDigits);
            }
        }
    }
    
    public override string GetSolutionPart1() {
      int calibrationSum = 0;
      foreach (List<int> digitLine in inputDigits) {
        calibrationSum +=  digitLine[0] * 10;
        calibrationSum +=  digitLine[digitLine.Count - 1];
      }
      return calibrationSum.ToString();
    }

    public override String GetSolutionPart2() {
        return "tbd";
    }
}
