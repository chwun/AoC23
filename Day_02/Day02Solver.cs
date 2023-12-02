using Base;
using System.Text.RegularExpressions;

namespace Day_02;

public class Day02Solver : SolverBase
{
    public override int SolvePart1(IEnumerable<string> lines)
    {
        List<Game> games = ParseGames(lines);
        return games.Where(x => x.MaxRed <= 12 && x.MaxGreen <= 13 && x.MaxBlue <= 14).Sum(x => x.Id);
    }

    public override int SolvePart2(IEnumerable<string> lines)
    {
        List<Game> games = ParseGames(lines);
        return games.Sum(x => x.Power);
    }

    private static List<Game> ParseGames(IEnumerable<string> lines)
    {
        List<Game> games = new();

        foreach (string line in lines)
        {
            Match matchGame = Regex.Match(line, "Game (?<game>[0-9]+):");
            Game game = new(int.Parse(matchGame.Groups["game"].Value));

            var sets = line.Split(';');
            foreach (string set in sets)
            {
                int red = 0;
                int green = 0;
                int blue = 0;

                Match redMatch = Regex.Match(set, "(?<red>[0-9]+) red");
                if (redMatch.Success)
                {
                    red = int.Parse(redMatch.Groups["red"].Value);
                }

                Match greenMatch = Regex.Match(set, "(?<green>[0-9]+) green");
                if (greenMatch.Success)
                {
                    green = int.Parse(greenMatch.Groups["green"].Value);
                }

                Match blueMatch = Regex.Match(set, "(?<blue>[0-9]+) blue");
                if (blueMatch.Success)
                {
                    blue = int.Parse(blueMatch.Groups["blue"].Value);
                }

                game.AddSet(red, green, blue);
            }

            games.Add(game);
        }

        return games;
    }
}