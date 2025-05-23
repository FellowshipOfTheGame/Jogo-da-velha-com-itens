using UnityEngine;

public class ProtectSquare : ItemBase
{
    public override string Name => "Escudo Divino";
    [SerializeField] private Sprite icon;
    public override Sprite Icon => icon;
    public override string Explanation => "Protege uma casa contra efeitos";
    public override int Cost => 2;

    public override bool Activate(VelhaBoard board, VelhaSquare square, Player player)
    {
        square.isProtected = true;
        return true;
    }
}