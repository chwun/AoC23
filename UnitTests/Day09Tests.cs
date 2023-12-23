using Day_09;
using System.Numerics;

namespace UnitTests;

public class Day09Tests : TestBase
{
    private readonly List<string> input = new()
    {
        "0 3 6 9 12 15",
        "1 3 6 10 15 21",
        "10 13 16 21 30 45"
    };

    public override void Part1Sample()
    {
        var sut = new Day09Solver();

        BigInteger result = sut.SolvePart1(input);

        result.Should().Be(114);
    }

    public override void Part2Sample()
    {
        var sut = new Day09Solver();

        BigInteger result = sut.SolvePart2(input);

        result.Should().Be(2);
    }
}