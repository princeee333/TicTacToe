using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to TicTacToe!");
        
        Game game = new Game();
        game.Start();
    }
}