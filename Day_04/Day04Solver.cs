using System.Text.RegularExpressions;
using Base;

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

				var ownWinningNumbers = winningNumbers.Intersect(ownNumbers);
				sum += (int)Math.Pow(2, ownWinningNumbers.Count() - 1);
			}
		}

		return sum;
	}

	public override int SolvePart2(IEnumerable<string> lines)
	{
		return 0;
	}
}