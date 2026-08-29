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
            activePiece = oPiece;

            board.PrintBoard(activePiece);
            Console.WriteLine();
            Console.WriteLine();

            while (board.MoveDown(activePiece))
            {
              
            }
            board.AddPiece(activePiece);

            board.PrintBoard();

            activePiece = lPiece;

            Console.WriteLine();
            Console.WriteLine();

            while (board.MoveDown(activePiece))
            {

            }
            board.AddPiece(activePiece);

            board.PrintBoard();
        }
    }
}
