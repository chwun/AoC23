using Day_07;
using System.Numerics;

namespace UnitTests;

public class Day07Tests : TestBase
{
    private List<string> input = new()
    {
        "32T3K 765",
        "T55J5 684",
        "KK677 28",
        "KTJJT 220",
        "QQQJA 483"
    };

    public override void Part1Sample()
    {
        Day07Solver sut = new();

        BigInteger result = sut.SolvePart1(input);

        result.Should().Be(6440);
    }

    public override void Part2Sample()
    {
        Day07Solver sut = new();

        BigInteger result = sut.SolvePart2(input);

        result.Should().Be(5905);
    }
}