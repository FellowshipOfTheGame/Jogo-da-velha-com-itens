using UnityEngine;

public class InvertPieces : ItemBase
{
    public override string Name => "Espelho Divino";
    [SerializeField] private Sprite icon;
    public override Sprite Icon => icon;
    public override string Explanation => "Inverte todas as peças do tabuleiro";
    public override int Cost => 7;

    public override bool Activate(VelhaBoard board, VelhaSquare square, Player player)
    {
        foreach (var s in board.squares)
        {
            if (s.isProtected)
            {
                s.isProtected = false;
                continue;
            }
            if (s.SquareState is SquareState.Both or SquareState.None)
                continue;
            
            s.SquareState = s.SquareState == SquareState.O ? SquareState.X : SquareState.O; 
        }
        return true;
    }
}