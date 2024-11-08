using UnityEngine;

public abstract class ItemBase
{
    public string Name { get; set; }
    public Sprite Icon { get; set; }
    public string Explanation { get; set; }
    public int Cost { get; set; }
    public abstract void Activate();
}
