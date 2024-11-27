using UnityEngine;

public class BoardShift : ItemBase
{
    public override string Name => "Derrapada Tectônica";
    public override Sprite Icon => null;
    public override string Explanation => "Shift no tabuleiro (direção aleatória)";
    public override int Cost => 4;

    public override bool Activate(VelhaBoard board, VelhaSquare square, Player player)
    {
        switch (Random.Range(0, 1))
        {
            case 0:
                for (var i = 0; i < board._dimension; i++)
                {
                    var last = board.squares[i, board._dimension - 1].SquareState; 
                    for (var j = 1; j < board._dimension; j++)
                    {
                        board.squares[i, j].SquareState = board.squares[i, j - 1].SquareState;
                    }

                    board.squares[i, 0].SquareState = last;
                }
                break;
            case 1:
                for (var j = 1; j < board._dimension; j++)
                {
                    var last = board.squares[board._dimension - 1, j].SquareState; 
                    for (var i = 1; i < board._dimension; i++)
                    {
                        board.squares[i, j].SquareState = board.squares[i - 1, j - 1].SquareState;
                    }

                    board.squares[0, j].SquareState = last;
                }
                break;
            case 2:
                for (var i = board._dimension - 2; i >= 0; i--)
                {
                    var first = board.squares[i, 0].SquareState; 
                    for (var j = board._dimension - 2; j > 0; j--)
                    {
                        board.squares[i, j].SquareState = board.squares[i + 1, j + 1].SquareState;
                    }

                    board.squares[i, board._dimension-1].SquareState = first;
                }
                break;
            case 3:
                for (var j = board._dimension - 2; j >= 0; j--)
                {
                    var first = board.squares[0, j].SquareState; 
                    for (var i = board._dimension - 2; i > 0; i--)
                    {
                        board.squares[i, j].SquareState = board.squares[i + 1, j + 1].SquareState;
                    }

                    board.squares[board._dimension-1 ,j].SquareState = first;
                }
                break;
        }
        

        return true;
    }
}

