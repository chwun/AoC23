//Dictionary<string, int> lettersToDigits = new()
//{
//	["one"] = 1,
//	["two"] = 2,
//	["three"] = 3,
//	["four"] = 4,
//	["five"] = 5,
//	["six"] = 6,
//	["seven"] = 7,
//	["eight"] = 8,
//	["nine"] = 9
//};

string[] lines = File.ReadAllLines("input.txt");

int sum1 = GetSum(lines);
Console.WriteLine($"part 1: {sum1}");

//int sum2 = GetSum(lines.Select(ConvertLettersToDigits));
//Console.WriteLine($"part 2: {sum2}");

int GetSum(IEnumerable<string> lines)
{
	return lines
		.Select(l => string.Join("", l.First(char.IsDigit), l.Last(char.IsDigit)))
		.Sum(int.Parse);
}

//string ConvertLettersToDigits(string input)
//{
//	foreach ((string letters, int digit) in lettersToDigits)
//	{
//		input = input.Replace(letters, digit.ToString());
//	}

//	return input;
//}