using TetrisGame.Entities;
using TetrisGame.Entities.Enums;

namespace TetrisGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Piece activePiece;
            int activeRow = 0;
            int activeColumn = 4;

            Random random = new Random();
            PieceType[] pieceTypes = new PieceType[7] { PieceType.O, PieceType.L, PieceType.I, PieceType.T, PieceType.S, PieceType.Z, PieceType.J };
            int score = 0;

            while (true)
            {
                int randomIndex = random.Next(pieceTypes.Length);
                activePiece = new Piece(pieceTypes[randomIndex], activeRow, activeColumn);

                if (board.CanPlacePiece(activePiece) == false)
                {
                    Console.Clear();
                    Console.WriteLine("PERDEU PLAYBOY!");
                    Console.WriteLine();
                    Console.WriteLine($"SCORE: {score} Points");
                    break;
                }

                FallPiece(board, activePiece, score);

                board.AddPiece(activePiece);
                score += board.ClearCompletedRows() * 100;
                Console.Clear();
                board.PrintBoard();
                Console.WriteLine();
                Console.WriteLine($"SCORE: {score} Points");
            }
        }

        public static void FallPiece(Board board, Piece activePiece, int score)
        {
            while (board.MoveDown(activePiece))
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo activeKey = Console.ReadKey(true);

                    if (activeKey.Key == ConsoleKey.R)
                    {
                        board.RotatePiece(activePiece);
                    }

                    if (activeKey.Key == ConsoleKey.RightArrow)
                    {
                        board.MoveRight(activePiece);
                    }
                    if (activeKey.Key == ConsoleKey.LeftArrow)
                    {
                        board.MoveLeft(activePiece);
                    }
                    if (activeKey.Key == ConsoleKey.DownArrow)
                    {
                        board.MoveDown(activePiece);
                    }
                }

                Console.Clear();
                board.PrintBoard(activePiece);
                Console.WriteLine();
                Console.WriteLine($"SCORE: {score} Points");
                Console.WriteLine("Controles: < > mover | V descer | R rotacionar");
                Thread.Sleep(500);
            }
        }
    }

}
