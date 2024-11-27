using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerItems : MonoBehaviour
{
    [SerializeField] private Player owner; 
    public ItemButton currentSelectedItem;
    [SerializeField] protected PlayerManager playerManager;
    public List<ItemButton> Items  { get; } = new();

    public virtual void ToggleItemSelected(ItemButton item)
    {
        if (owner != playerManager.TurnPlayer)
            return;
        currentSelectedItem?.ToggleItemSelected();
        currentSelectedItem = item;
        currentSelectedItem.ToggleItemSelected();   
    }

    public abstract void ConfirmItemSelection();
}
