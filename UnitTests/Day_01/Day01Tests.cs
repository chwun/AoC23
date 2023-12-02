using Day_01;
using UnitTests;

namespace _01.Tests.Day_01;

public class Day01Tests : TestBase
{
    public override void Part1Sample()
    {
        List<string> input = new()
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };
        Day01Solver sut = new();

        int result = sut.SolvePart1(input);

        result.Should().Be(142);
    }

    public override void Part2Sample()
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
        Day01Solver sut = new();

        int result = sut.SolvePart2(input);

        result.Should().Be(281);
    }
}