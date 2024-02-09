namespace AOC2023.Days.Day08;

public class CamelMaps(string lRSequence, Dictionary<string, (string, string)> mappings)
{
    public int FollowMaps()
    {
        string currentPosition = lRSequence[0] == 'L' ? mappings["AAA"].Item1 : mappings["AAA"].Item2;
        // start steps at 1 since first step sis AAA to something, likewise placeInLRSequence
        int numberOfSteps = 1;
        int placeInLrSequence = 1;
        while (currentPosition != "ZZZ")
        {
            currentPosition = lRSequence[placeInLrSequence] == 'L' 
                ? mappings[currentPosition].Item1 
                : mappings[currentPosition].Item2;
            numberOfSteps++;
            placeInLrSequence = placeInLrSequence < lRSequence.Length - 1 ? placeInLrSequence + 1 : 0;
        }
        return numberOfSteps;
    }

    public long FollowAsIfGhost()
    {
        var startingPositions = mappings.Keys.Where(key => key[2] == 'A');
        var multiples = startingPositions.Select(GetMultiples);
        var multiplesCartesianProduct = CartesianProduct(multiples);
        var allLCMs = multiplesCartesianProduct.Select(CalcLCM);
        return allLCMs.Min();
    }

    private List<long> GetMultiples(string position)
    {
        HashSet<string> visited = [];
        int step = 0;
        int placeInLrSequence = 0;
        List<long> multiples = [];
        string positionAndPlaceInLrSequence = position + placeInLrSequence;
        while (!visited.Contains(positionAndPlaceInLrSequence))
        {
            visited.Add(positionAndPlaceInLrSequence);
            position = lRSequence[placeInLrSequence] == 'L' 
                ? mappings[position].Item1 
                : mappings[position].Item2;
            placeInLrSequence = placeInLrSequence < lRSequence.Length - 1 ? placeInLrSequence + 1 : 0;
            positionAndPlaceInLrSequence = position + placeInLrSequence;
            step++;
            if (position[2] != 'Z') continue;
            multiples.Add(step);
        }
        return multiples;
    }

   public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences) 
   {
     // base case: 
     IEnumerable<IEnumerable<T>> result = 
       new[] { Enumerable.Empty<T>() };
     return sequences.Aggregate(result, (current, s) =>
         from seq in current from item in s select seq.Concat(new[] { item })); 
   } 

    public static long CalcLCM(IEnumerable<long> multiples)
    {
        var primeFactors = multiples.Select(CalcPrimeFactors).ToList();
        long lcm = 1; 
        for (int i = 2; i <= multiples.Max(); i++)
        {
            int howMany = 0;
            foreach (Dictionary<long, int> multiplePrimeFactors in primeFactors)
            {
                if (multiplePrimeFactors.Keys.Contains(i))
                {
                    howMany = Math.Max(multiplePrimeFactors[i], howMany);
                }
            }

            if (howMany > 0)
            {
                lcm = howMany * i * lcm;
            }
        }
        return lcm;
    }

    public static Dictionary<long, int> CalcPrimeFactors(long number)
    {
        Dictionary<long, int> primeFactors = new();
        while (!IsPrime(number))
        {
            int i = 2;
            while (number % i != 0 || !IsPrime(i))
            {
                i++;
            }
            
            number /= i;
            if (primeFactors.Keys.Contains(i))
            {
                primeFactors[i] += 1;
            }
            else
            {
                primeFactors.Add(i, 1);
            }
        }
        if (primeFactors.Keys.Contains(number))
        {
            primeFactors[number] += 1;
        }
        else
        {
            primeFactors.Add(number, 1);
        }
        return primeFactors;
    }
    public static bool IsPrime(long number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (long)Math.Floor(Math.Sqrt(number));
              
        for (long i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;
        return true;        
    }
        
}