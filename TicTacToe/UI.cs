public class UI
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
    
    public int GetPlayerInput()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 9)
        {
            DisplayMessage("Invalid input. Please enter a number between 1 and 9:");
        }
        return input;
    }
}