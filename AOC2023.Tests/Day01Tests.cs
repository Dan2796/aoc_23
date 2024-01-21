using AOC2023.Days.Day01;
using FluentAssertions;

namespace AOC2023.Tests;

public class Day01Tests
{
    [Fact]
    public void Day01_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day01 day = new();
        string TestInput = "1abc2\n" +
                           "pqr3stu8vwx\n" +
                           "a1b2c3d4e5f\n" +
                           "treb7uchet";
        StreamReader TestInputStream = TestMethods.StringToStreamReader(TestInput);
        // Act
        int result = day.ParseAndSolveP1(TestInputStream);
        // Assert
        result.Should().Be(142);
    }
    
}
