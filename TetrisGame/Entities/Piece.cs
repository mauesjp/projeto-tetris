namespace TetrisGame.Entities
{
    internal class Piece
    {
        private int[,] _shape;

        public int ActiveRow { get; set; }
        public int ActiveColumn { get; set; }

        public Piece(char piece, int activeRow, int activeColumn)
        {
            ActiveRow = activeRow;
            ActiveColumn = activeColumn;

            if(piece == 'O')
            {
                _shape = new int[2, 2] 
                { 
                  { 1, 1 },
                  { 1, 1 } 
                };
            }
            else if(piece == 'L')
            {
                _shape = new int[3, 2]
                {
                  { 1, 0 },
                  { 1, 0 },
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
    }
}
