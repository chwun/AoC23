using Day_01;

string[] lines = File.ReadAllLines("input.txt");

Solver solver = new();

int sum1 = Solver.SolvePart1(lines);
Console.WriteLine($"part 1: {sum1}");

int sum2 = solver.SolvePart2(lines);
Console.WriteLine($"part 2: {sum2}");