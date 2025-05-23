using UnityEngine;

public class EraseSquare : ItemBase
{
    public override string Name => "Bola de fogo";
    [SerializeField] private Sprite icon;
    public override Sprite Icon => icon;
    public override string Explanation => "Destroi a peça de uma casa";
    public override int Cost => 3;

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
