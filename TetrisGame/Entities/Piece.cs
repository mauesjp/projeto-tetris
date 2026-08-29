namespace TetrisGame.Entities
{
    internal class Piece
    {
        private int[,] _shape;

        public int Row { get; set; }
        public int Column { get; set; }

        public Piece(char piece, int row, int column)
        {
            Row = row;
            Column = column;

            if(piece == 'O')
            {
                _shape = new int[2, 2] 
                { 
                  { 1, 1 },
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
