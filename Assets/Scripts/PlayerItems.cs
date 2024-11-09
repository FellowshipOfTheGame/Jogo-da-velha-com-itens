using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    private List<ItemSelectButton> playerItems = new();
    
    public void AddItemToCurrentPlayer(ItemSelectButton item)
    {
        playerItems.Add(item);
        var button = Instantiate(item, transform);
    }

    public void RemoveItemFromCurrentPlayer(ItemSelectButton item)
    {
        playerItems.Remove(item);
    }
}
