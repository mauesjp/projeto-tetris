using TetrisGame.Entities.Enums;

namespace TetrisGame.Entities
{
    internal class Game
    {
        private readonly Board _board = new Board();
        private int _score = 0;

        private readonly Random _random = new Random();
        private readonly PieceType[] _pieceTypes = new PieceType[7] { PieceType.O, PieceType.L, PieceType.I, PieceType.T, PieceType.S, PieceType.Z, PieceType.J };

        private const int InitialRow = 0;
        private const int InitialColumn = 4;
        private const int PointsPerLine = 100;
        private const int FallDelayMilliseconds = 500;
        private const int InputCheckDelayMilliseconds = 50;

        public void Run()
        {

            while (true)
            {
                Piece activePiece;
                int randomIndex = _random.Next(_pieceTypes.Length);
                activePiece = new Piece(_pieceTypes[randomIndex], InitialRow, InitialColumn);

                if (_board.CanPlacePiece(activePiece) == false)
                {
                    Console.Clear();
                    Console.WriteLine("PERDEU PLAYBOY!");
                    Console.WriteLine();
                    Console.WriteLine($"SCORE: {_score} Points");
                    break;
                }

                FallPiece(activePiece);

                _board.AddPiece(activePiece);
                _score += _board.ClearCompletedRows() * PointsPerLine;
                Console.Clear();
                _board.PrintBoard();
                Console.WriteLine();
                Console.WriteLine($"SCORE: {_score} Points");
            }
        }

        private void FallPiece(Piece activePiece)
        {
            while (_board.MoveDown(activePiece))
            {
                for (int i = 0; i < FallDelayMilliseconds / InputCheckDelayMilliseconds; i++)
                {
                    HandleInput(activePiece);

                    Console.Clear();
                    _board.PrintBoard(activePiece);
                    Console.WriteLine();
                    Console.WriteLine($"SCORE: {_score} Points");
                    Console.WriteLine("Controles: < > mover | V descer | R rotacionar");
                    Thread.Sleep(InputCheckDelayMilliseconds);
                }

            }
        }

        private void HandleInput(Piece activePiece)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo activeKey = Console.ReadKey(true);

                if (activeKey.Key == ConsoleKey.R)
                {
                    _board.RotatePiece(activePiece);
                }

                if (activeKey.Key == ConsoleKey.RightArrow)
                {
                    _board.MoveRight(activePiece);
                }
                if (activeKey.Key == ConsoleKey.LeftArrow)
                {
                    _board.MoveLeft(activePiece);
                }
                if (activeKey.Key == ConsoleKey.DownArrow)
                {
                    _board.MoveDown(activePiece);
                }
            }
        }
    }
}
