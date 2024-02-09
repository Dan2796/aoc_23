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
                                      "ZZZ = (ZZZ, ZZZ)\n";

    private const string TestInput3 = "LR\n" +
                                      "\n" + 
                                      "11A = (11B, XXX)\n" +
                                      "11B = (XXX, 11Z)\n" +
                                      "11Z = (11B, XXX)\n" +
                                      "22A = (22B, XXX)\n" +
                                      "22B = (22C, 22C)\n" +
                                      "22C = (22Z, 22Z)\n" +
                                      "22Z = (22B, 22B)\n" +
                                      "XXX = (XXX, XXX)\n";
    
    private readonly Day08 _day = new();
    private readonly StreamReader _testInputStream1 = MethodsForTesting.StringToStreamReader(TestInput1);
    private readonly StreamReader _testInputStream2 = MethodsForTesting.StringToStreamReader(TestInput2);
    private readonly StreamReader _testInputStream3 = MethodsForTesting.StringToStreamReader(TestInput3);
    
    [Fact]
    public void Day08_ParseAndSolveP1_ReturnCorrectAnswerTest1()
    { 
        var result = _day.ParseAndSolveP1(_testInputStream1);
        result.Should().Be(2);
    }
    
    [Fact]
    public void Day08_ParseAndSolveP1_ReturnCorrectAnswerTest2()
    { 
        var result = _day.ParseAndSolveP1(_testInputStream2);
        result.Should().Be(6);
    }

    [Fact]
    public void Day08_ParseAndSolveP2_ReturnCorrectAnswer() 
    { 
        long result = _day.ParseAndSolveP2(_testInputStream3);
        result.Should().Be(6);
    }
}
