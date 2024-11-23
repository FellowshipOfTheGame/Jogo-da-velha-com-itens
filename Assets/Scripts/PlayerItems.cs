using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerItems : MonoBehaviour
{
    protected ItemButton currentSelectedItem;
    [SerializeField] protected PlayerManager playerManager;
    public List<ItemButton> Items  { get; } = new();

    public void ToggleItemSelected(ItemButton item)
    {
        currentSelectedItem?.ToggleItemSelected();
        currentSelectedItem = item;
        currentSelectedItem.ToggleItemSelected();   
    }

    public ItemBase ConfirmItemSelection()
    {
        Items.Add(currentSelectedItem);
        Instantiate(currentSelectedItem.GetComponent<Button>().image, transform);
        var toReturn = currentSelectedItem.Item;
        currentSelectedItem = null;
        return toReturn;
    }
}
