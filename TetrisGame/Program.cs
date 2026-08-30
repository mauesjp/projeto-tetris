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

            while(true)
            {
                int randomIndex = random.Next(pieceTypes.Length);
                activePiece = new Piece(pieceTypes[randomIndex],activeRow, activeColumn);

                if (board.CanPlacePiece(activePiece) == false)
                {
                    Console.Clear();
                    Console.WriteLine("PERDEU PLAYBOY!");
                    break;
                }

                FallPiece(board, activePiece);

                board.AddPiece(activePiece);
                Console.Clear();
                board.PrintBoard();
            }
        }

        public static void FallPiece(Board board, Piece activePiece)
        {
            while (board.MoveDown(activePiece))
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo activeKey = Console.ReadKey(true);

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
                Thread.Sleep(500);
            }
        }
    }

}
