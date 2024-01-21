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
        const string testInput = "1abc2\n" +
                                 "pqr3stu8vwx\n" +
                                 "a1b2c3d4e5f\n" +
                                 "treb7uchet";
        StreamReader testInputStream = MethodsForTesting.StringToStreamReader(testInput);
        // Act
        int result = day.ParseAndSolveP1(testInputStream);
        // Assert
        result.Should().Be(142);
    }
    
    [Fact]
    public void Day01_ParseAndSolveP2_ReturnCorrectAnswer()
        {
            // Arrange
            Day01 day = new();
            const string testInput = "two1nine\n" +
                                     "eightwothree\n" +
                                     "abcone2threexyz\n" +
                                     "xtwone3four\n" +
                                     "4nineeightseven2\n" +
                                     "zoneight234\n" +
                                     "7pqrstsixteen";
            StreamReader testInputStream = MethodsForTesting.StringToStreamReader(testInput);
            // Act
            int result = day.ParseAndSolveP2(testInputStream);
            // Assert
            result.Should().Be(281);
        }
}
