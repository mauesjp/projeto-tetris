namespace TetrisGame.Entities
{
    class Board
    {
        private const int Rows = 20;
        private const int Columns = 10;
        private const int Width = 2;

        private int[,] _board { get; set; } = new int[Rows, Columns];

        public void PrintBoard(Piece activePiece) // imprime o tabuleiro, recebendo a peça
        {
            Console.WriteLine(PrintBorder());

            for (int row = 0; row < _board.GetLength(0); row++) // percorre linhas
            {
                Console.Write("|");
                for (int column = 0; column < _board.GetLength(1); column++) // percorre colunas
                {
                    bool isActivePieceCell = false; // verifica se a peça ocupa a celula que esta sendo verificada, inicia como false pois ainda nao foi verificado

                    int pieceRow = row - activePiece.ActiveRow; //variavel que armazena o valor convertido da linha da peça no tabuleiro 
                    int pieceColumn = column - activePiece.ActiveColumn; //variavel que armazena o valor convertido da coluna da peça no tabuleiro 

                    bool isInsidePiece = pieceRow >= 0 // verifica se pieceRow e pieceColumn estão dentro da matriz da peça
                        && pieceRow < activePiece.GetHeight()
                        && pieceColumn >= 0
                        && pieceColumn < activePiece.GetWidth();

                    if (isInsidePiece)
                    {
                        isActivePieceCell = activePiece.GetCell(pieceRow, pieceColumn) != 0; // se as condiçoes impostas anteriormente forem verdadeiras, verifica o formato da peça usando != 0 para identificar onde há desenho da peça
                    }
                    Console.Write(PrintCell(_board[row, column] != 0 || isActivePieceCell));
                }
                Console.WriteLine("|"); // pula a linha para imprimir a proxima linha
            }
            Console.WriteLine(PrintBorder());
        }

        public void PrintBoard() // imprime o tabuleiro, com a peça fixa
        {
            Console.WriteLine(PrintBorder());

            for (int row = 0; row < _board.GetLength(0); row++) // percorre linhas
            {
                Console.Write("|");
                for (int column = 0; column < _board.GetLength(1); column++) // percorre colunas
                {
                    Console.Write(PrintCell(_board[row,column] != 0));
                }
                Console.WriteLine("|"); // pula a linha para imprimir a proxima linha
            }
            Console.WriteLine(PrintBorder());
        }

        public void SetPosition(int row, int column) // grava no tabuleiro a posiçao fixa da peça quando ela parar de cair
        {
            _board[row, column] = 1;
        }

        public void AddPiece(Piece piece) // adiciona a peça de forma fixa no tabuleiro
        {
            if (CanPlacePiece(piece))
            {
                for (int rowPiece = 0; rowPiece < piece.GetHeight(); rowPiece++)
                {
                    for (int columnPiece = 0; columnPiece < piece.GetWidth(); columnPiece++)
                    {
                        if (piece.GetCell(rowPiece, columnPiece) == 1) // depois de percorrer linhas e colunas da matriz da peça verifica se é igual a 1 para poder saber o formato dela
                        {
                            SetPosition(rowPiece + piece.ActiveRow, columnPiece + piece.ActiveColumn); // se a celula tiver 1 nela, então deve ser gravada no tabuleiro
                        }
                    }
                }
            }
        }

        public bool CanPlacePiece(Piece piece) // verifica se é possivel colocar uma peça no local que esta sendo verificado, leva em conta o tamanho da peça e a posiçao que ela vai ocupar no tabuleiro
        {
            for (int rowPiece = 0; rowPiece < piece.GetHeight(); rowPiece++) // percorre o tamanho da peça em linhas (quantas linhas a peça ocupa)
            {
                for (int columnPiece = 0; columnPiece < piece.GetWidth(); columnPiece++) // percorre o tamanho da peça em colunas (quantas colunas a peça ocupa)
                {
                    int boardRow = rowPiece + piece.ActiveRow; // variavel que armazena a posiçao real da linha que a peca vai ocupar no tabuleiro
                    int boardColumn = columnPiece + piece.ActiveColumn; // variavel que armazena a posiçao real da coluna que a peca vai ocupar no tabuleiro

                    if (piece.GetCell(rowPiece, columnPiece) == 1) // verifica a celula da peça para saber o formato 
                    {
                        if (boardRow < 0 || boardRow >= _board.GetLength(0) // verifica se a celula da peça está fora do tabuleiro
                            || boardColumn < 0
                            || boardColumn >= _board.GetLength(1))
                        {
                            return false;
                        }
                        if (_board[boardRow, boardColumn] == 1) // verifica se ja ha alguma peça naquela celula 
                        {
                            return false;
                        }
                    }
                }
            }
            return true; // se passar pelas verificaçoes, retorna verdadeiro para poder setar a peça
        }


        public bool MoveDown(Piece activePiece) // logica para mover a peça para baixo
        {
            activePiece.ActiveRow = activePiece.ActiveRow + 1; // adiciona uma linha a linha atual

            if (CanPlacePiece(activePiece)) // verifica se pode colocar a peça 
            {
                return true;
            }
            else
            {
                activePiece.ActiveRow = activePiece.ActiveRow - 1; // se nao puder retira a linha adicionada e mantem a peça na mesma posiçao original
                return false;
            }
        }

        public bool MoveLeft(Piece activePiece)
        {
            activePiece.ActiveColumn = activePiece.ActiveColumn - 1;

            if (CanPlacePiece(activePiece))
            {
                return true;
            }
            else
            {
                activePiece.ActiveColumn = activePiece.ActiveColumn + 1;
                return false;
            }
        }

        public bool MoveRight(Piece activePiece)
        {
            activePiece.ActiveColumn = activePiece.ActiveColumn + 1;

            if (CanPlacePiece(activePiece))
            {
                return true;
            }
            else
            {
                activePiece.ActiveColumn = activePiece.ActiveColumn - 1;
                return false;
            }
        }

        public bool RotatePiece(Piece activePiece)
        {
            activePiece.Rotate();

            if (CanPlacePiece(activePiece))
            {
                return true;
            }
            else
            {
                activePiece.Rotate();
                activePiece.Rotate();
                activePiece.Rotate();
                return false;
            }
        }

        public bool IsRowComplete(int row)
        {
            for (int i = 0; i < _board.GetLength(1); i++)
            {
                if (_board[row, i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void ClearRow(int completedRow)
        {
            for (int i = completedRow; i > 0; i--)
            {
                for(int j = 0; j < _board.GetLength(1); j++)
                {
                    _board[i, j] = _board[i - 1, j];
                }
            }

            for(int j = 0; j < _board.GetLength(1); j++)
            {
                _board[0, j] = 0;
            }
        }

        public int ClearCompletedRows()
        {
            int row = _board.GetLength(0) - 1;
            int clearedRows = 0;
            
            while(row >= 0)
            {
                if (IsRowComplete(row))
                {
                    ClearRow(row);
                    clearedRows++;
                }
                else
                {
                    row--;
                }
            }
            return clearedRows;
        }

        private string PrintBorder()
        {
            return "+" + new string('-', Width * Columns) + "+";
        }

        private string PrintCell(bool isFilled)
        {
            if (isFilled)
            {
                return "[]";
            }
            else
                return " .";
        }
    }
}
