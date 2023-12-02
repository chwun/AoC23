using Base;

namespace Day_01;

public class Day01Solver : SolverBase
{
    private Dictionary<string, int> textToDigits = new()
    {
        ["one"] = 1,
        ["two"] = 2,
        ["three"] = 3,
        ["four"] = 4,
        ["five"] = 5,
        ["six"] = 6,
        ["seven"] = 7,
        ["eight"] = 8,
        ["nine"] = 9,
        ["1"] = 1,
        ["2"] = 2,
        ["3"] = 3,
        ["4"] = 4,
        ["5"] = 5,
        ["6"] = 6,
        ["7"] = 7,
        ["8"] = 8,
        ["9"] = 9,
    };

    public override int SolvePart1(IEnumerable<string> lines)
    {
        return lines
            .Select(l => string.Join("", l.First(char.IsDigit), l.Last(char.IsDigit)))
            .Sum(int.Parse);
    }

    public override int SolvePart2(IEnumerable<string> lines)
    {
        int sum = 0;

        foreach (string line in lines)
        {
            int minIndex = int.MaxValue;
            int firstDigit = -1;
            int maxIndex = int.MinValue;
            int lastDigit = -1;

            foreach ((string text, int digit) in textToDigits)
            {
                int firstIndex = line.IndexOf(text);
                if (firstIndex > -1 && firstIndex < minIndex)
                {
                    minIndex = firstIndex;
                    firstDigit = digit;
                }

                int lastIndex = line.LastIndexOf(text);
                if (lastIndex > -1 && lastIndex > maxIndex)
                {
                    maxIndex = lastIndex;
                    lastDigit = digit;
                }
            }

            int number = firstDigit * 10 + lastDigit;
            sum += number;
        }

        return sum;
    }
}