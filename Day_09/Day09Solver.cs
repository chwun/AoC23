using Base;

namespace Day_09;

public class Day09Solver : SolverBase
{
    public override int SolvePart1(IEnumerable<string> lines)
    {
        List<List<int>> sequences = lines.Select(x => x.Split(' ').Select(int.Parse).ToList()).ToList();

        int sum = 0;

        foreach (var sequence in sequences)
        {
            List<List<int>> extrapolatedSequences = CreateExtrapolatedSequences(sequence);

            for (int i = extrapolatedSequences.Count - 2; i >= 0; i--)
            {
                int newNumber = extrapolatedSequences[i].Last() + extrapolatedSequences[i + 1].Last();
                extrapolatedSequences[i].Add(newNumber);
            }

            sum += extrapolatedSequences.First().Last();
        }

        return sum;
    }

    public override int SolvePart2(IEnumerable<string> lines)
    {
        List<List<int>> sequences = lines.Select(x => x.Split(' ').Select(int.Parse).ToList()).ToList();

        int sum = 0;

        foreach (var sequence in sequences)
        {
            List<List<int>> extrapolatedSequences = CreateExtrapolatedSequences(sequence);

            for (int i = extrapolatedSequences.Count - 2; i >= 0; i--)
            {
                int newNumber = extrapolatedSequences[i].First() - extrapolatedSequences[i + 1].First();
                extrapolatedSequences[i].Insert(0, newNumber);
            }

            sum += extrapolatedSequences.First().First();
        }

        return sum;
    }

    private static List<List<int>> CreateExtrapolatedSequences(List<int> sequence)
    {
        List<List<int>> extrapolatedSequences = new()
        {
            sequence
        };
        var currentSeq = sequence;

        while (currentSeq.Any(x => x != 0))
        {
            List<int> newSequence = new();

            for (int i = 0; i < currentSeq.Count - 1; i++)
            {
                int diff = currentSeq[i + 1] - currentSeq[i];
                newSequence.Add(diff);
            }

            extrapolatedSequences.Add(newSequence);
            currentSeq = newSequence;
        }

        return extrapolatedSequences;
    }
}