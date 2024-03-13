public class Player
{
    public string Name { get; init; }
    public char Symbol { get; init; }

    public Player(char symbol, string name)
    {
        Symbol = symbol;
        Name = name;
    }
}