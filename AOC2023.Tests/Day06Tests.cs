using AOC2023.Days.Day06;
using FluentAssertions;

namespace AOC2023.Tests;

public class Day06Tests
{
    private const string TestInput = "Time:      7  15   30\n" +
                                     "Distance:  9  40  200";
    private readonly Day06 _day = new();
    private readonly StreamReader _testInputStream = MethodsForTesting.StringToStreamReader(TestInput);
    
    [Fact]
    public void Day06_ParseAndSolveP1_ReturnCorrectAnswer()
    { 
        long result = _day.ParseAndSolveP1(_testInputStream);
        result.Should().Be(288);
    }
    /*
    [Fact]
    public void Day06_ParseAndSolveP2_ReturnCorrectAnswer() 
    { 
        long result = _day.ParseAndSolveP2(_testInputStream);
        result.Should().Be(288);
    }
    */
}
