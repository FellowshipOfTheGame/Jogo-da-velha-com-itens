using UnityEngine;
using UnityEngine.UI;

public class ItemSelectButton : MonoBehaviour
{
    public PlayerItems PlayerItems;
    public ItemBase Item;
    // private bool isSelected;
    private void Start () 
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ToggleItemSelected);
    }

    private void ToggleItemSelected() 
    {
        PlayerItems.ToggleItemSelected(this);
        // TODO highlight do botao
        // if (isSelected)
        // {
        //     isSelected = false;
        //     // TODO tirar o highlight
        // }
        // else
        // {
        //     isSelected = true;
        //     // TODO highlight no item
        // }
    }
    
    // overrides para verificar se os botoes sao iguais dentro de uma list
    public override string ToString() => Item.Name;
    public override int GetHashCode() => Item.Name.GetHashCode();
    public override bool Equals(object obj) => Item.Name == ((ItemSelectButton)obj).Item.Name;
}
