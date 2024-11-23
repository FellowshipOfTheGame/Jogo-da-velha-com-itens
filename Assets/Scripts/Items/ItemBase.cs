using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract Sprite Icon { get; }
    public abstract string Explanation { get; }
    public abstract int Cost { get; }
    public abstract bool Activate(VelhaBoard board, VelhaSquare square, Player player);
}
