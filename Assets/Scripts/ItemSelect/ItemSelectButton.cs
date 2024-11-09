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
        btn.onClick.AddListener(ToggleItemSelected);
    }

    private void ToggleItemSelected() 
    {
        if (isSelected)
        {
            isSelected = false;
            PlayerItems.RemoveItemFromCurrentPlayer(this);
            // tirar o highlight
        }
        else
        {
            isSelected = true;
            PlayerItems.AddItemToCurrentPlayer(this);
            // highlight no item
        }
    }
}
