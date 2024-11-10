using UnityEngine;

public class ExtraPlay : ItemBase
{
    public override string Name => "Pacto Infernal";
    public override Sprite Icon => null;
    public override string Explanation => "Pode fazer mais uma jogada nesse turno";
    public override int Cost => 2;
    public override void Activate()
    {
        throw new System.NotImplementedException();
    }
}
