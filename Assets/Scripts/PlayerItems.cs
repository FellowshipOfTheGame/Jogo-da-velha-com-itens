using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    private List<ItemSelectButton> playerItems = new();

    public void ToggleItemSelected(ItemSelectButton item)
    {
        var index = playerItems.IndexOf(item);
        if (index == -1)
        {
            playerItems.Add(item);
            Instantiate(item, transform);
        }
        else
        {
            Destroy(transform.GetChild(index).gameObject);
            playerItems.RemoveAt(index);
        }
    }
}
