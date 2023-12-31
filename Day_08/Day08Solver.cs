﻿using Base;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Day_08;

public class Day08Solver : SolverBaseBig
{
    public override BigInteger SolvePart1(IEnumerable<string> lines)
    {
        var (instructions, nodes) = ParseData(lines);

        string currentNodeId = "AAA";
        var currentNode = nodes[currentNodeId];
        long steps = 0;
        bool finished = false;

        do
        {
            foreach (char instruction in instructions)
            {
                currentNodeId = instruction == 'L' ? currentNode.left : currentNode.right;
                currentNode = nodes[currentNodeId];
                steps++;

                if (currentNodeId == "ZZZ")
                {
                    finished = true;
                    break;
                }
            }
        }
        while (!finished);

        return steps;
    }

    public override BigInteger SolvePart2(IEnumerable<string> lines)
    {
        return 0;
    }

    private static (char[] instructions, Dictionary<string, (string left, string right)> nodes) ParseData(IEnumerable<string> lines)
    {
        var instructions = lines.First().ToCharArray();
        var nodes = lines.Skip(2).Select(x =>
        {
            var match = Regex.Match(x, @"(?<nodeId>[A-Z]{3}) = \((?<left>[A-Z]{3}), (?<right>[A-Z]{3})\)");

            return new KeyValuePair<string, (string, string)>(
                match.Groups["nodeId"].Value,
                (match.Groups["left"].Value, match.Groups["right"].Value));
        }).ToDictionary(x => x.Key, x => x.Value);

        return (instructions, nodes);
    }
}