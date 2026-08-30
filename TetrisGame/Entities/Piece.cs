using TetrisGame.Entities.Enums;

namespace TetrisGame.Entities
{
    internal class Piece
    {
        private int[,] _shape;

        public int ActiveRow { get; set; }
        public int ActiveColumn { get; set; }

        public Piece(PieceType pieceType, int activeRow, int activeColumn)
        {
            ActiveRow = activeRow;
            ActiveColumn = activeColumn;

            if(pieceType == PieceType.O)
            {
                _shape = new int[2, 2] 
                { 
                  { 1, 1 },
                  { 1, 1 } 
                };
            }
            else if(pieceType == PieceType.L)
            {
                _shape = new int[3, 2]
                {
                  { 1, 0 },
                  { 1, 0 },
                  { 1, 1 }
                };
            }
            else if(pieceType == PieceType.I)
            {
                _shape = new int[4, 1]
                {
                  { 1 },
                  { 1 },
                  { 1 },
                  { 1 }
                };
            }
            else if(pieceType == PieceType.T)
            {
                _shape = new int[2, 3]
                {
                  { 1, 1, 1 },
                  { 0, 1, 0 }
                };
            }
            else if(pieceType == PieceType.Z)
            {
                _shape = new int[2, 3]
                {
                  { 1, 1, 0 },
                  { 0, 1, 1 }
                };
            }
            else if(pieceType == PieceType.S)
            {
                _shape = new int[3, 2]
                {
                  { 0, 1 },
                  { 1, 1 },
                  { 1, 0 }
                };
            }
            else if(pieceType == PieceType.J)
            {
                _shape = new int[3, 2]
                {
                  { 0, 1 },
                  { 0, 1 },
                  { 1, 1 }
                };
            }
        }

        public int GetHeight()
        {
            return _shape.GetLength(0);
        }

        public int GetWidth()
        {
            return _shape.GetLength(1);
        }

        public int GetCell(int row, int column)
        {
            return _shape[row, column];
        }

        public void Rotate()
        {
            int[,] newShape = new int[_shape.GetLength(1), _shape.GetLength(0)];

            for(int row = 0; row < _shape.GetLength(0); row++)
            {
                for(int column = 0; column < _shape.GetLength(1); column++)
                {
                    newShape[column, GetHeight() - 1 - row] = _shape[row, column];
                }
            }
            _shape = newShape;
        }
    }
}
