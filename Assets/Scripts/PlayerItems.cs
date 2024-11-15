using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    public List<ItemSelectButton> ConfirmedItems  { get; } = new();
    private ItemSelectButton currentSelectedItem;

    public void ToggleItemSelected(ItemSelectButton item)
    {
        currentSelectedItem?.ToggleItemSelectedColor();
        currentSelectedItem = item;
        currentSelectedItem.ToggleItemSelectedColor();
    }

    public void ConfirmItemSelection()
    {
        ConfirmedItems.Add(currentSelectedItem);
        Instantiate(currentSelectedItem.GetComponent<Button>().image, transform);
        currentSelectedItem = null;
    }
}
