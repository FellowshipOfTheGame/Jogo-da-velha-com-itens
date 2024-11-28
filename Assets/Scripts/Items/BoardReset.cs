using UnityEngine;

public class BoardReset : ItemBase
{
    public override string Name => "Dilúvio";
    public override Sprite Icon => null;
    public override string Explanation => "Apaga todas as peças do tabuleiro";
    public override int Cost => 6;

    public override bool Activate(VelhaBoard board, VelhaSquare square, Player player)
    {
        foreach (var s in board.squares)
        {
            if (s.isProtected)
            {
                s.isProtected = false;
                continue;
            }
            s.SquareState = SquareState.None;
        }
        return true;
    }
}
