using System.Numerics;

namespace Base;

public abstract class SolverBaseBig
{
    public void SolveAndPrintOutput()
    {
        string[] lines = File.ReadAllLines("input.txt");

        BigInteger part1 = SolvePart1(lines);
        Console.WriteLine($"part 1: {part1}");

        BigInteger part2 = SolvePart2(lines);
        Console.WriteLine($"part 2: {part2}");
    }

    public abstract BigInteger SolvePart1(IEnumerable<string> lines);

    public abstract BigInteger SolvePart2(IEnumerable<string> lines);


}