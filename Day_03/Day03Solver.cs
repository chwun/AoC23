using Base;
using System.Text;

namespace Day_03;

public class Day03Solver : SolverBase
{
    public override int SolvePart1(IEnumerable<string> lines)
    {
        var matrix = lines.Select(x => x.ToCharArray()).ToArray();

        List<int> digits = new();

        for (int row = 0; row < matrix.Length; row++)
        {
            bool numberActive = false;
            bool numberAdjacentToSymbol = false;
            StringBuilder numberDigits = new();

            for (int col = 0; col < matrix[row].Length; col++)
            {
                char c = matrix[row][col];
                if (char.IsDigit(c))
                {
                    numberActive = true;
                    numberDigits.Append(c);

                    if (IsAdjacentToSymbol(row, col, matrix))
                    {
                        numberAdjacentToSymbol = true;
                    }
                }
                else
                {
                    if (numberActive && numberAdjacentToSymbol)
                    {
                        digits.Add(int.Parse(numberDigits.ToString()));
                    }

                    numberActive = false;
                    numberAdjacentToSymbol = false;
                    numberDigits.Clear();
                }
            }

            if (numberActive && numberAdjacentToSymbol)
            {
                digits.Add(int.Parse(numberDigits.ToString()));
            }
        }

        return digits.Sum();
    }

    public override int SolvePart2(IEnumerable<string> lines)
    {
        return 0;
    }

    private static bool IsAdjacentToSymbol(int row, int col, char[][] matrix)
    {
        int rowMinus1 = Math.Max(row - 1, 0);
        int rowPlus1 = Math.Min(row + 1, matrix.Length - 1);
        int colMinus1 = Math.Max(col - 1, 0);
        int colPlus1 = Math.Min(col + 1, matrix[col].Length - 1);

        return CharIsSymbol(matrix[rowMinus1][colMinus1])
            || CharIsSymbol(matrix[rowMinus1][col])
            || CharIsSymbol(matrix[rowMinus1][colPlus1])
            || CharIsSymbol(matrix[row][colMinus1])
            || CharIsSymbol(matrix[row][colPlus1])
            || CharIsSymbol(matrix[rowPlus1][colMinus1])
            || CharIsSymbol(matrix[rowPlus1][col])
            || CharIsSymbol(matrix[rowPlus1][colPlus1]);
    }

    private static bool CharIsSymbol(char c)
    {
        return !char.IsDigit(c) && c != '.';
    }
}