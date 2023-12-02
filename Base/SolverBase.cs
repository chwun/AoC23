namespace Base;

public abstract class SolverBase
{
    public void SolveAndPrintOutput()
    {
        string[] lines = File.ReadAllLines("input.txt");

        int part1 = SolvePart1(lines);
        Console.WriteLine($"part 1: {part1}");

        int part2 = SolvePart2(lines);
        Console.WriteLine($"part 2: {part2}");
    }

    public abstract int SolvePart1(IEnumerable<string> lines);

    public abstract int SolvePart2(IEnumerable<string> lines);


}