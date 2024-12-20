using UnityEngine;

public class EraseSquare : ItemBase
{
    public override string Name => "Bola de fogo";
    public override Sprite Icon => null;
    public override string Explanation => "Destroi a peça de uma casa";
    public override int Cost => 2;

    public override bool Activate(VelhaBoard board, VelhaSquare square, Player player)
    {
        if (square.isProtected)
        {
            square.isProtected = false;
            return true;
        }

        square.SquareState = SquareState.None;
        return true;
    }
}
