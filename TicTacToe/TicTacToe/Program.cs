using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace TicTacToe
{
    internal class Program
    {

        static int currentRowValue = 0;
        static int currentColumnValue = 0;

        static string[,] board = new string[,]
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"},
            };
        static void Main(string[] args)
        {
            int playerNumber = 0;
            string playerAction;

            while (Checker(board, currentRowValue, currentColumnValue) != true)
            {
                playerNumber = (playerNumber == 1) ? 2 : 1;
                string playerSymbol = (playerNumber == 1) ? "O" : "X";

                SetBoard(board);
                Console.Write($"\nPlayer {playerNumber}: Choose your field! ");

                playerAction = Console.ReadLine();

                while (ValidateInput(board, playerAction) == false)
                {
                    Console.Write($"\nPlayer {playerNumber}: Choose your field! ");
                    playerAction = Console.ReadLine();

                }

                SetNumber(board, playerAction, playerSymbol);

                Console.Clear();

            }

            SetBoard(board);

            Console.WriteLine($"Congratulations Player{playerNumber}: You win!");

        }

        static bool ValidateInput(string[,] board, string playerAction)
        {
            bool isNumber = int.TryParse(playerAction, out int number);

            if (isNumber == false)
            {
                Console.WriteLine("Please enter a valid number!");
                return false;
            }
            else if (NumberIsPresent(board, playerAction) == false)
            {
                Console.WriteLine("Number already taken");
                return false;
            }
            return true;
        }

        static bool NumberIsPresent(string[,] board, string playerAction)
        {
            foreach (string position in board)
            {
                if (position == playerAction)
                {
                    return true;
                }
            }
            return false;
        }

        static void SetNumber(string[,] board, string playerPositionSelect, string playerSymbol)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == playerPositionSelect)
                    {
                        board[row, col] = playerSymbol;
                        currentRowValue = row;
                        currentColumnValue = col;

                    }
                }
            }
        }

        static bool Checker(string[,] board, int i, int j)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return true;
            }
            if (board[0, j] == board[1, j] && board[1, j] == board[2, j])
            {
                return true;
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;
        }

        static void SetBoard(string[,] board)
        {
            Console.WriteLine("      |      |");
            Console.WriteLine("   " + board[0, 0] + "  |   " + board[0, 1] + "  |   " + board[0, 2]);
            Console.WriteLine("______|______|______");
            Console.WriteLine("      |      |");
            Console.WriteLine("   " + board[1, 0] + "  |   " + board[1, 1] + "  |   " + board[1, 2]);
            Console.WriteLine("______|______|______");
            Console.WriteLine("      |      |");
            Console.WriteLine("   " + board[2, 0] + "  |   " + board[2, 1] + "  |   " + board[2, 2]);
            Console.WriteLine("      |      |");
        }

    }
}