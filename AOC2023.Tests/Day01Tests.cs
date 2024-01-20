using System.Text;
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
        //string TestInput = "TestInputs/Day01.txt";
        string TestInput = "1abc2\n" +
                           "pqr3stu8vwx\n" +
                           "a1b2c3d4e5f\n" +
                           "treb7uchet";
        byte[] byteArray = Encoding.UTF8.GetBytes(TestInput);
        MemoryStream stream = new(byteArray);
        StreamReader reader = new(stream);
        // Act
        int result = day.ParseAndSolveP1(reader);
        // Assert
        result.Should().Be(142);
    }
    
}
