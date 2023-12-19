using System.Collections.Concurrent;
using System.Numerics;

namespace Day_05;

public class Day05Solver
{
    public BigInteger SolvePart1(IEnumerable<string> lines)
    {
        var seeds = lines.ElementAt(0).Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(BigInteger.Parse);
        return GetLowestSeedLocation(lines, seeds);
    }

    public BigInteger SolvePart2(IEnumerable<string> lines)
    {
        var seedsRaw = lines.ElementAt(0).Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(BigInteger.Parse).ToArray();

        List<(BigInteger rangeStart, BigInteger rangeLength)> seedRanges = new();

        for (int i = 0; i < seedsRaw.Length - 1; i += 2)
        {
            seedRanges.Add((seedsRaw[i], seedsRaw[i + 1]));
        }

        var seeds = seedRanges.SelectMany(x => GenerateBigIntegerRange(x.rangeStart, x.rangeLength)).ToList();

        return GetLowestSeedLocation(lines, seeds);
    }

    public void SolveAndPrintOutput()
    {
        string[] lines = File.ReadAllLines("input.txt");

        BigInteger part1 = SolvePart1(lines);
        Console.WriteLine($"part 1: {part1}");

        BigInteger part2 = SolvePart2(lines);
        Console.WriteLine($"part 2: {part2}");
    }

    private static BigInteger GetLowestSeedLocation(IEnumerable<string> lines, IEnumerable<BigInteger> seeds)
    {
        List<List<(BigInteger sourceRangeStart, BigInteger destinationRangeStart, BigInteger rangeLength)>> ranges = new();

        foreach (string line in lines.Skip(2))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (char.IsLetter(line[0]))
            {
                // new map
                ranges.Add(new());
            }
            else
            {
                // add to last map
                var currentRanges = ranges[^1];

                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();

                BigInteger destinationRangeStart = numbers[0];
                BigInteger sourceRangeStart = numbers[1];
                BigInteger rangeLength = numbers[2];

                currentRanges.Add((sourceRangeStart, destinationRangeStart, rangeLength));
            }
        }

        //List<BigInteger> seedLocations = new();
        ConcurrentBag<BigInteger> seedLocations = new();

        //foreach (BigInteger seed in seeds)
        Parallel.ForEach(seeds, seed =>
        {
            BigInteger currentKey = seed;
            BigInteger currentValue = 0;

            foreach (var currentRanges in ranges)
            {
                bool found = false;

                foreach (var (sourceRangeStart, destinationRangeStart, rangeLength) in currentRanges)
                {
                    if (currentKey >= sourceRangeStart && currentKey < sourceRangeStart + rangeLength)
                    {
                        currentValue = destinationRangeStart + (currentKey - sourceRangeStart);
                        currentKey = currentValue;

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    currentValue = currentKey;
                }
            }

            seedLocations.Add(currentValue);
        });

        return seedLocations.Min();
    }

    private static IEnumerable<BigInteger> GenerateBigIntegerRange(BigInteger start, BigInteger length)
    {
        for (BigInteger i = start; i < start+length; i++)
        {
            yield return i;
        }
    }
}