using AOC2023.Days.Day09;
using FluentAssertions;

namespace AOC2023.Tests;

public class Day09Test
{
    private const string TestInput = "0 3 6 9 12 15\n" +
                                     "1 3 6 10 15 21\n" +
                                     "10 13 16 21 30 45\n";
    private readonly Day09 _day = new();
    private readonly StreamReader _testInputStream = MethodsForTesting.StringToStreamReader(TestInput);
    
    [Fact]
    public void Day09_()
    {
        var result = _day.ParseAndSolveP1(_testInputStream);
        result.Should().Be(2);
    }
}