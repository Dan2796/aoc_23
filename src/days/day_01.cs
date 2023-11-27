using System.Security.AccessControl;

class Day01(Boolean actual) : Day(actual)
{
    public override int GetDay() {
        return 1;
    }
    List<int> calorieNumbers = new List<int>();

    public override void ParseInput() {

        int calorieCounter = 0;
        using (StreamReader reader = new StreamReader(GetFileName()))
        {
            while (!reader.EndOfStream)
            {
                string calorie = reader.ReadLine();
                if (!ObjectSecurity.Equals(calorie, "")) 
                {
                    calorieCounter += Int32.Parse(calorie);
                } else 
                {
                    calorieNumbers.Add(calorieCounter);
                    calorieCounter = 0;
                }
            }
            }
        // add last number in list:
        calorieNumbers.Add(calorieCounter);
        calorieNumbers.Sort();
        calorieNumbers.Reverse();
    }

    public override String GetSolutionPart1() {
        return calorieNumbers[0].ToString();
    }

    public override String GetSolutionPart2() {
        int total = calorieNumbers[0] + calorieNumbers[1] + calorieNumbers[2];
        return total.ToString();
    }
}
