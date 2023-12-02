namespace Day_02;

internal class Game
{
    public int Id { get; set; }

    public int MaxRed { get; set; }
    public int MaxGreen { get; set; }
    public int MaxBlue { get; set; }

    public int Power => MaxRed * MaxGreen * MaxBlue;

    public Game(int id)
    {
        Id = id;
    }

    public void AddSet(int red, int green, int blue)
    {
        MaxRed = int.Max(MaxRed, red);
        MaxGreen = int.Max(MaxGreen, green);
        MaxBlue = int.Max(MaxBlue, blue);
    }
}