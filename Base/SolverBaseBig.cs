using System.Diagnostics;
using System.Numerics;

namespace Base;

public abstract class SolverBaseBig
{
    public void SolveAndPrintOutput()
    {
        string[] lines = File.ReadAllLines("input.txt");

        Stopwatch sw = Stopwatch.StartNew();

        BigInteger part1 = SolvePart1(lines);
        sw.Stop();
        Console.WriteLine($"part 1: {part1} (took {sw.ElapsedMilliseconds:N0} ms)");

        sw.Restart();
        BigInteger part2 = SolvePart2(lines);
        sw.Stop();
        Console.WriteLine($"part 2: {part2} (took {sw.ElapsedMilliseconds:N0} ms)");
    }

    public abstract BigInteger SolvePart1(IEnumerable<string> lines);

    public abstract BigInteger SolvePart2(IEnumerable<string> lines);


}