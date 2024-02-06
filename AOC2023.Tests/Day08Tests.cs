using AOC2023.Days.Day08;
using FluentAssertions;

namespace AOC2023.Tests;

public class Day08Tests
{
    private const string TestInput1 = "RL\n" +
                                      "\n" +
                                      "AAA = (BBB, CCC)\n" +
                                      "BBB = (DDD, EEE)\n" +
                                      "CCC = (ZZZ, GGG)\n" +
                                      "DDD = (DDD, DDD)\n" +
                                      "EEE = (EEE, EEE)\n" +
                                      "GGG = (GGG, GGG)\n" +
                                      "ZZZ = (ZZZ, ZZZ\n";

    private const string TestInput2 = "LLR\n" +
                                      "\n" +
                                      "AAA = (BBB, BBB)\n" +
                                      "BBB = (AAA, ZZZ)\n" +
                                      "ZZZ = (ZZZ, ZZZ) \n";
    
    private readonly Day08 _day = new();
    private readonly StreamReader _testInputStream1 = MethodsForTesting.StringToStreamReader(TestInput1);
    private readonly StreamReader _testInputStream2 = MethodsForTesting.StringToStreamReader(TestInput2);
    
    [Fact]
    public void Day08_ParseAndSolveP1_ReturnCorrectAnswerTest1()
    { 
        var result = _day.ParseAndSolveP1(_testInputStream1);
        result.Should().Be(0);
        //result.Should().Be(2);
    }
    
    [Fact]
    public void Day08_ParseAndSolveP1_ReturnCorrectAnswerTest2()
    { 
        var result = _day.ParseAndSolveP1(_testInputStream2);
        result.Should().Be(0);
        //result.Should().Be(6);
    }

    [Fact]
    public void Day08_ParseAndSolveP2_ReturnCorrectAnswer() 
    { 
        long result = _day.ParseAndSolveP2(_testInputStream1);
        result.Should().Be(0);
    }
}
