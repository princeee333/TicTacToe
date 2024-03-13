public class Board
{
    private char[,] board = new char[3, 3];

    public Board()
    {
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        int number = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = char.Parse(number.ToString());
                number++;
            }
        }
    }

    public void DisplayBoard()
    {
        Console.WriteLine("   0   1   2");
        Console.WriteLine(" ┌───┬───┬───┐");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + "│");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(" " + board[i, j]  + " ");
                if (j < 2)
                    Console.Write("│");
            }
            Console.WriteLine("│");
            if (i < 2)
                Console.WriteLine(" ├───┼───┼───┤");
        }
        Console.WriteLine(" └───┴───┴───┘");
    }
    
    public bool IsPositionFree(int row, int col)
    {
        return board[row, col] >= '1' && board[row, col] <= '9';
    }

    public void MakeMove(int row, int col, char playerSymbol)
    {
        if (IsPositionFree(row, col))
        {
            board[row, col] = playerSymbol;
        }
    }

    public bool CheckWin()
    {
        //Check rows
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2] && board[row, 0] != '.')
                return true;
        }

        //Check columns
        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] == board[1, col] && board[1, col] == board[2, col] && board[0, col] != '.')
                return true;
        }

        //Check diagonal primary
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != '.')
            return true;

        //Check diagonal secondary
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != '.')
            return true;

        return false;
    }


    public bool CheckDraw()
    {
        return false;
    }
}