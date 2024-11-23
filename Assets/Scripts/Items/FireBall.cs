using UnityEngine;

public class FireBall : ItemBase
{
    public override string Name => "Bola de fogo";
    public override Sprite Icon => null;
    public override string Explanation => "Destroi a peça de uma casa";
    public override int Cost => 4;

    public override bool Activate(VelhaBoard board, VelhaSquare square, Player player)
    {
        throw new System.NotImplementedException();
    }
}
