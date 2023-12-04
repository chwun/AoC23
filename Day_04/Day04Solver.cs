using Base;
using System.Text.RegularExpressions;

namespace Day_04;

public class Day04Solver : SolverBase
{
    public override int SolvePart1(IEnumerable<string> lines)
    {
        int sum = 0;

        foreach (string line in lines)
        {
            Match match = Regex.Match(line, @"Card[0-9\s]+:(?<winningNumbers>[0-9\s]+)\|(?<ownNumbers>[0-9\s]+)");
            if (match.Success)
            {
                var winningNumbers = match.Groups["winningNumbers"].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
                var ownNumbers = match.Groups["ownNumbers"].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

                int numberOfOwnWinningNumbers = winningNumbers.Intersect(ownNumbers).Count();
                sum += (int)Math.Pow(2, numberOfOwnWinningNumbers - 1);
            }
        }

        return sum;
    }

    public override int SolvePart2(IEnumerable<string> lines)
    {
        int instances = 0;

        Dictionary<int, int> instancesPerCardNumber = new();

        foreach (string line in lines)
        {
            Match match = Regex.Match(line, @"Card(?<cardNumber>[0-9\s]+):(?<winningNumbers>[0-9\s]+)\|(?<ownNumbers>[0-9\s]+)");
            if (match.Success)
            {
                int cardNumber = int.Parse(match.Groups["cardNumber"].Value);

                if (!instancesPerCardNumber.ContainsKey(cardNumber))
                {
                    instancesPerCardNumber[cardNumber] = 0;
                }

                var winningNumbers = match.Groups["winningNumbers"].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
                var ownNumbers = match.Groups["ownNumbers"].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

                int numberOfOwnWinningNumbers = winningNumbers.Intersect(ownNumbers).Count();
                for (int i = cardNumber + 1; i <= cardNumber + numberOfOwnWinningNumbers; i++)
                {
                    if (!instancesPerCardNumber.ContainsKey(i))
                    {
                        instancesPerCardNumber[i] = 0;
                    }

                    instancesPerCardNumber[i] += instancesPerCardNumber[cardNumber] + 1;
                }

                instances += instancesPerCardNumber.TryGetValue(cardNumber, out int numberOfInstances) ? numberOfInstances + 1 : 1;
            }
        }

        return instances;
    }
}