using UnityEngine;

public class SquareSwap : ItemBase
{
    public override string Name => "Colônia Assimilacionista";
    public override Sprite Icon => null;
    public override string Explanation => "Troca uma peça do oponente por uma sua";
    public override int Cost => 6;

    public override bool Activate(VelhaBoard board, VelhaSquare square, Player player)
    {
        if (square.SquareState != SquareState.O && square.SquareState != SquareState.X)
            return false;
        
        if (square.isProtected)
        {
            square.isProtected = false;
            return true;
        }
        
        square.SquareState = square.SquareState == SquareState.O ? SquareState.X : SquareState.O;
        return true;
    }
}