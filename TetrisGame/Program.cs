using TetrisGame.Entities;

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

            Piece oPiece = new Piece('O', activeRow, activeColumn);
            Piece lPiece = new Piece('L', activeRow, activeColumn);

            activePiece = lPiece;

            while (board.MoveDown(activePiece))
            {
                Console.Clear();
                board.PrintBoard(activePiece);
                Thread.Sleep(500);
            }
            board.AddPiece(activePiece);
            Console.Clear();
            board.PrintBoard();

            activePiece = oPiece;

            while (board.MoveDown(activePiece))
            {
                Console.Clear();
                board.PrintBoard(activePiece);
                Thread.Sleep(500);
            }
            board.AddPiece(activePiece);
            Console.Clear();
            board.PrintBoard();
        }
    }
}
