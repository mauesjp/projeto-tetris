using TetrisGame.Entities;

namespace TetrisGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Piece pieceO = new Piece('O', 5, 3);

            board.AddPiece(pieceO);

            board.PrintBoard();


            
        }
    }
}
