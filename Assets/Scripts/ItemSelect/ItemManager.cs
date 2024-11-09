using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<ItemBase> availableItems;
    [SerializeField] private ItemSelectButton itemSelectButton;
    [SerializeField] private PlayerManager playerManager;

    private void Start()
    {
        foreach (var item in availableItems)
        {
            var button = Instantiate(itemSelectButton, transform);
            button.Item = item;
            button.PlayerItems = playerManager.GetCurrentPlayerItems();
        }
    }
}
