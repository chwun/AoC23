using Day_06;
using System.Numerics;

namespace UnitTests;

public class Day06Tests : TestBase
{
    private readonly List<string> input = new()
        {
            "Time:      7  15   30",
            "Distance:  9  40  200"
        };

    public override void Part1Sample()
    {
        Day06Solver sut = new();

        BigInteger result = sut.SolvePart1(input);

        result.Should().Be(288);
    }

    public override void Part2Sample()
    {
        Day06Solver sut = new();

        BigInteger result = sut.SolvePart2(input);

        result.Should().Be(71503);
    }
}