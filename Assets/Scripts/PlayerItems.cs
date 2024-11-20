using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerItems : MonoBehaviour
{
    protected ItemButton currentSelectedItem;
    [SerializeField] protected PlayerManager playerManager;
    public List<ItemButton> Items  { get; } = new();

    public abstract void ToggleItemSelected(ItemButton item);

    public abstract void ConfirmItemSelection();
}
