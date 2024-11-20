using UnityEngine;

public abstract class ItemButton : MonoBehaviour
{
    public PlayerItems PlayerItems;
    public ItemBase Item;
    protected bool isSelected;
    
    public abstract void ToggleItemSelected();
    
    // overrides para verificar se os botoes sao iguais dentro de uma list
    public override string ToString() => Item.Name;
    public override int GetHashCode() => Item.Name.GetHashCode();
    public override bool Equals(object obj) => Item.Name == ((ItemButton)obj).Item.Name;
}
