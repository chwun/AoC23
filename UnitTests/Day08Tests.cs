using Day_08;
using System.Numerics;

namespace UnitTests;

public class Day08Tests : TestBase
{
    private readonly List<string> input = new()
    {
        "RL",
        "",
        "AAA = (BBB, CCC)",
        "BBB = (DDD, EEE)",
        "CCC = (ZZZ, GGG)",
        "DDD = (DDD, DDD)",
        "EEE = (EEE, EEE)",
        "GGG = (GGG, GGG)",
        "ZZZ = (ZZZ, ZZZ)"
    };

    public override void Part1Sample()
    {
        Day08Solver sut = new Day08Solver();

        BigInteger result = sut.SolvePart1(input);

        result.Should().Be(2);
    }

    public override void Part2Sample()
    {
        Day08Solver sut = new Day08Solver();

        BigInteger result = sut.SolvePart2(input);

        result.Should().Be(6);
    }
}