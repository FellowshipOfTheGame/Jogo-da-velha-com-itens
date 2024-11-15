using UnityEngine;
using UnityEngine.UI;

public class ItemSelectButton : MonoBehaviour
{
    public PlayerItems PlayerItems;
    public ItemBase Item;
    private bool isSelected;
    private void Start () 
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => PlayerItems.ToggleItemSelected(this));
    }

    public void ToggleItemSelectedColor() 
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
    public override bool Equals(object obj) => Item.Name == ((ItemSelectButton)obj).Item.Name;
}
