using Base;
using System.Numerics;

namespace Day_06;

public class Day06Solver : SolverBaseBig
{
    public override BigInteger SolvePart1(IEnumerable<string> lines)
    {
        var times = lines.ElementAt(0).Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(BigInteger.Parse).ToArray();
        var distances = lines.ElementAt(1).Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(BigInteger.Parse).ToArray();

        return CalculateResult(times, distances);
    }

    public override BigInteger SolvePart2(IEnumerable<string> lines)
    {
        BigInteger time = BigInteger.Parse(string.Join("", lines.ElementAt(0).Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1)));
        BigInteger distance = BigInteger.Parse(string.Join("", lines.ElementAt(1).Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1)));

        return CalculateResult(new[] { time }, new[] { distance });
    }

    private BigInteger CalculateResult(BigInteger[] times, BigInteger[] distances)
    {
        int result = 1;

        for (int i = 0; i < times.Length; i++)
        {
            int recordBeaten = 0;

            for (BigInteger buttonDuration = 1; buttonDuration < times[i] - 1; buttonDuration++)
            {
                BigInteger distance = (times[i] - buttonDuration) * buttonDuration;

                if (distance > distances[i])
                {
                    recordBeaten++;
                }
            }

            result *= recordBeaten;
        }

        return result;
    }
}