namespace TetrisGame.Entities
{
    class Board
    {
        private int[,] _board { get; set; } = new int[20, 10];

        public void PrintBoard()
        {
            for (int row = 0; row < _board.GetLength(0); row++)
            {
                for (int column = 0; column < _board.GetLength(1); column++)
                {

                    Console.Write(_board[row, column] + " ");
                }
                Console.WriteLine();
            }
        }

        public void SetPosition(int row, int column)
        {
            _board[row, column] = 1;
        }

        public void AddPiece(Piece piece)
        {
            if (CanPlacePiece(piece))
            {
                for (int rowPiece = 0; rowPiece < piece.GetHeight(); rowPiece++)
                {
                    for (int columnPiece = 0; columnPiece < piece.GetWidth(); columnPiece++)
                    {
                        if (piece.GetCell(rowPiece, columnPiece) == 1)
                        {
                            SetPosition(rowPiece + piece.Row, columnPiece + piece.Column);
                        }
                    }
                }
            }
        }

        public bool CanPlacePiece(Piece piece)
        {
            for (int rowPiece = 0; rowPiece < piece.GetHeight(); rowPiece++)
            {
                for (int columnPiece = 0; columnPiece < piece.GetWidth(); columnPiece++)
                {
                    int boardRow = rowPiece + piece.Row;
                    int boardColumn = columnPiece + piece.Column;

                    if (piece.GetCell(rowPiece, columnPiece) == 1)
                    {
                        if (boardRow < 0 || boardRow >= _board.GetLength(0) 
                            || boardColumn < 0 
                            || boardColumn >= _board.GetLength(1))
                        {
                            return false;
                        }
                        if (_board[boardRow, boardColumn] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
