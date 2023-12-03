using Day_03;

namespace UnitTests;

public class Day03Tests : TestBase
{
    public override void Part1Sample()
    {
        List<string> input = new()
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        };

        Day03Solver sut = new();

        int result = sut.SolvePart1(input);

        result.Should().Be(4361);
    }

    public override void Part2Sample()
    {
        throw new NotImplementedException();
    }
}