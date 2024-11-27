using UnityEngine;

public class SquareBothPieces : ItemBase
{
    public override string Name => "Entrelaçamento Quântico";
    public override Sprite Icon => null;
    public override string Explanation => "Uma peça de cada jogador ocupa a mesma casa";
    public override int Cost => 4;

    public override bool Activate(VelhaBoard board, VelhaSquare square, Player player)
    {
        if (square.SquareState != SquareState.O && square.SquareState != SquareState.X)
            return false;
        
        if (square.isProtected)
        {
            square.isProtected = false;
            return true;
        }
        
        square.SquareState = SquareState.Both;
        return true;
    }
}