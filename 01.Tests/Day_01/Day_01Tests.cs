using Day_01;
using FluentAssertions;

namespace _01.Tests.Day_01;

public class Day_01Tests
{
    [Fact]
    public void Part1Sample()
    {
        List<string> input = new()
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };
        Solver sut = new();

        int result = Solver.SolvePart1(input);

        result.Should().Be(142);
    }

    [Fact]
    public void Part2Sample()
    {
        List<string> input = new()
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };
        Solver sut = new();

        int result = sut.SolvePart2(input);

        result.Should().Be(281);
    }
}