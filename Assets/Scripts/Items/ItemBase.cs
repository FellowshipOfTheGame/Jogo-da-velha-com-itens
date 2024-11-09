using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract Sprite Icon { get; }
    public abstract string Explanation { get; }
    public abstract int Cost { get; }
    public abstract void Activate();
    public override string ToString() => Name;
    public override int GetHashCode() => Name.GetHashCode();
    public override bool Equals(object obj) => Name.Equals(((ItemBase)obj).Name);
}
