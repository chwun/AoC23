using Base;

namespace Day_07;

public class Day07Solver : SolverBase
{
    private readonly Dictionary<char, int> cardStrengths = new()
    {
        ['2'] = 1,
        ['3'] = 2,
        ['4'] = 3,
        ['5'] = 4,
        ['6'] = 5,
        ['7'] = 6,
        ['8'] = 7,
        ['9'] = 8,
        ['T'] = 9,
        ['J'] = 10,
        ['Q'] = 11,
        ['K'] = 12,
        ['A'] = 13,
    };

    public override int SolvePart1(IEnumerable<string> lines)
    {
        List<(string hand, int bid)> data = lines.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)).Select(x => (x[0], int.Parse(x[1]))).ToList();

        data.Sort(Compare);

        return data.Select((x, index) => (index + 1) * x.bid).Sum();
    }

    public override int SolvePart2(IEnumerable<string> lines)
    {
        return 0;
    }

    private int Compare((string hand, int bid) x, (string hand, int bid) y)
    {
        HandType typeX = GetType(x.hand);
        HandType typeY = GetType(y.hand);

        if (typeX != typeY)
        {
            return typeX.CompareTo(typeY);
        }

        for (int i = 0; i < 5; i++)
        {
            int strengthX = cardStrengths[x.hand[i]];
            int strengthY = cardStrengths[y.hand[i]];

            if (strengthX != strengthY)
            {
                return strengthX.CompareTo(strengthY);
            }
        }

        return 0;
    }

    private HandType GetType(string hand)
    {
        char firstChar = hand[0];
        if (hand.All(x => x == firstChar))
        {
            return HandType.FiveOfAKind;
        }

        var groups = hand.GroupBy(c => c);
        if (groups.Any(g => g.Count() == 4))
        {
            return HandType.FourOfAKind;
        }

        if (groups.Any(g => g.Count() == 3))
        {
            if (groups.Any(g => g.Count() == 2))
            {
                return HandType.FullHouse;
            }

            return HandType.ThreeOfAKind;
        }

        if (groups.Where(g => g.Count() == 2).Count() == 2)
        {
            return HandType.TwoPair;
        }

        if (groups.Any(g => g.Count() == 2))
        {
            return HandType.OnePair;
        }

        return HandType.HighCard;
    }
}