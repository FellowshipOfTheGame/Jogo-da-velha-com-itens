using UnityEngine;

public class NormalPlay : ItemBase
{
    public override string Name => "Jogada comum";
    public override Sprite Icon => null;
    public override string Explanation => "";
    public override int Cost => 0;
    public override bool Activate(VelhaBoard board, VelhaSquare square, Player player)
    {
        if (square.SquareState is not SquareState.None)
            return false;
        square.SquareState = player == Player.X ? SquareState.X : SquareState.O;
        return true;
    }
}
