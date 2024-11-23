using UnityEngine;
using UnityEngine.UI;

public abstract class ItemButton : MonoBehaviour
{
    public PlayerItems PlayerItems;
    public ItemBase Item;
    protected bool isSelected;
    
    protected void Start () 
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => PlayerItems.ToggleItemSelected(this));
    }

    public virtual void ToggleItemSelected()
    {
        if (isSelected)
        {
            isSelected = false;
            gameObject.GetComponent<Image>().color = Color.white;
        }
        else
        {
            isSelected = true;
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
    
    // overrides para verificar se os botoes sao iguais dentro de uma list
    public override string ToString() => Item.Name;
    public override int GetHashCode() => Item.Name.GetHashCode();
    public override bool Equals(object obj) => Item.Name == ((ItemButton)obj).Item.Name;
}
