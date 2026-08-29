namespace TetrisGame.Entities
{
    class Board
    {
        private int[,] _board { get; set; } = new int[20, 10];

        public void PrintBoard(Piece activePiece) // imprime o tabuleiro, recebendo a peça
        {
            for (int row = 0; row < _board.GetLength(0); row++) // percorre linhas
            {
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
                    if (_board[row, column] != 0 || isActivePieceCell) // utiliza OU para verificar e imprimir se a matriz principal já possui uma peça naquela celula, ou se a nova peça esta naquela celula
                    {
                        Console.Write("[]"); // imprime a parte da peça sem pular a linha
                    }
                    else
                    {
                        Console.Write(" ."); // senao celula vazia sem pular a linha
                    }
                }
                Console.WriteLine(); // pula a linha para imprimir a proxima linha
            }
        }

        public void PrintBoard() // imprime o tabuleiro, com a peça fixa
        {
            for (int row = 0; row < _board.GetLength(0); row++) // percorre linhas
            {
                for (int column = 0; column < _board.GetLength(1); column++) // percorre colunas
                {
                    if (_board[row, column] != 0) // verificar e imprimir se a matriz principal já possui uma peça naquela celula
                    {
                        Console.Write("[]"); // imprime a parte da peça sem pular a linha
                    }
                    else
                    {
                        Console.Write(" ."); // senao celula vazia sem pular a linha
                    }
                }
                Console.WriteLine(); // pula a linha para imprimir a proxima linha
            }
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


        public bool MoveDown(Piece activePiece)
        {
            activePiece.ActiveRow = activePiece.ActiveRow + 1;

            if (CanPlacePiece(activePiece))
            {
                return true;
            }
            else
            {
                activePiece.ActiveRow = activePiece.ActiveRow - 1;
                return false;
            }
        }
    }
}
