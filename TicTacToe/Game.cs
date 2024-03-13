using System;

public class Game
{
    private Board board;
    private Player player1;
    private Player player2;
    private Player currentPlayer;
    private Random random = new Random();
    private UI ui = new UI();

    public Game()
    {
        board = new Board();
        InitializePlayers();
        ChooseStartingPlayer();
    }

    private void InitializePlayers()
    {
        Console.Write("Enter name for Player 1: ");
        string name1 = Console.ReadLine();
        player1 = new Player('X', name1);

        Console.Write("Enter name for Player 2: ");
        string name2 = Console.ReadLine();
        player2 = new Player('O', name2);
    }

    private void ChooseStartingPlayer()
    {
        currentPlayer = random.Next(2) == 0 ? player1 : player2;
        Console.WriteLine($"{currentPlayer.Name} starts the game. Symbol: '{currentPlayer.Symbol}'");
    }

    private void ChangePlayer()
    {
        currentPlayer = currentPlayer == player1 ? player2 : player1;
    }

    public void Start()
    {
        bool gameEnded = false;
        while (!gameEnded)
        {
            Console.WriteLine();
            board.DisplayBoard(); 

            PlayTurn(); 
            
            if (board.CheckWin())
            {
                board.DisplayBoard(); 
                Console.ForegroundColor = ConsoleColor.Green;
                ui.DisplayMessage($"{currentPlayer.Name} wins!");
                Console.ResetColor();
                gameEnded = true;
            }
            else if (board.CheckDraw())
            {
                board.DisplayBoard(); 
                Console.ForegroundColor = ConsoleColor.Yellow;
                ui.DisplayMessage("It's a draw!");
                Console.ResetColor();
                gameEnded = true;
            }

            if (!gameEnded)
            {
                ChangePlayer(); 
            }
        }
    }


    public (int, int) ConvertInputToCoordinates(int input)
    {
        int row = (input - 1) / 3;
        int col = (input - 1) % 3;
        return (row, col);
    }

    public void PlayTurn()
    {
        bool isMoveValid = false;
        while (!isMoveValid)
        {
            int playerInput = ui.GetPlayerInput();
            var (row, col) = ConvertInputToCoordinates(playerInput);

            if (board.IsPositionFree(row, col))
            {
                board.MakeMove(row, col, currentPlayer.Symbol);
                isMoveValid = true;
            }
            else
            {
                ui.DisplayMessage("This position is already taken. Please try again.");
            }
        }
    }
}