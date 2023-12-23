using System.Diagnostics;
using System.Numerics;

namespace Base;

public abstract class SolverBase
{
    public void SolveAndPrintOutput()
    {
        string[] lines = File.ReadAllLines("input.txt");

        Stopwatch sw = Stopwatch.StartNew();

        int part1 = SolvePart1(lines);
        sw.Stop();
        Console.WriteLine($"part 1: {part1} (took {sw.ElapsedMilliseconds:N0} ms)");

        sw.Restart();
        int part2 = SolvePart2(lines);
        sw.Stop();
        Console.WriteLine($"part 2: {part2} (took {sw.ElapsedMilliseconds:N0} ms)");
    }

    public abstract int SolvePart1(IEnumerable<string> lines);

    public abstract int SolvePart2(IEnumerable<string> lines);


}