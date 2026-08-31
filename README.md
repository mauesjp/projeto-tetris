# Tetris em C#

Projeto desenvolvido em C# com o objetivo de praticar lógica de programação, programação orientada a objetos e estruturas de dados por meio da criação de um jogo Tetris para console.

## Tecnologias

* C#
* .NET
* Git
* GitHub

## Funcionalidades

* Tabuleiro de 20x10
* Sete tetraminós: O, I, T, S, Z, J e L
* Geração aleatória de peças
* Separação entre peça ativa e blocos fixos
* Queda automática
* Movimento para esquerda, direita e baixo
* Rotação das peças
* Validação dos limites do tabuleiro
* Detecção de colisões
* Fixação das peças
* Limpeza de linhas completas
* Sistema de pontuação
* Detecção de Game Over
* Leitura de comandos pelo teclado
* Loop principal do jogo
* Bordas visuais no tabuleiro
* Resposta rápida aos comandos
* Organização das responsabilidades nas classes `Game`, `Board` e `Piece`

## Controles

|Tecla|Ação|
|-|-|
|`←`|Mover para a esquerda|
|`→`|Mover para a direita|
|`↓`|Acelerar a descida|
|`R`|Rotacionar a peça|

## Pontuação

Cada linha completa removida adiciona 100 pontos à pontuação total.

## Como executar

Clone o repositório:

```bash
git clone https://github.com/mauesjp/projeto-tetris.git
```

Entre na pasta do projeto:

```bash
cd projeto-tetris
```

Execute o jogo:

```bash
dotnet run
```

## Estrutura principal

* `Game`: controla o loop da partida, a pontuação, a geração das peças e os comandos.
* `Board`: controla o tabuleiro, os movimentos, as colisões, a fixação e a limpeza de linhas.
* `Piece`: representa os formatos e a rotação dos tetraminós.
* `PieceType`: define os tipos de peças disponíveis.

## Possíveis melhorias futuras

* Cores diferentes para os tetraminós
* Exibição da próxima peça
* Níveis de dificuldade
* Aumento progressivo da velocidade
* Pausa e reinício da partida
* Testes automatizados

## Status

Projeto concluído para fins de estudo e prática dos fundamentos de C#.

