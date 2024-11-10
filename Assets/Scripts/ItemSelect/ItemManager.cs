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
        // criar o botoes para selecionar os itens a partir dos itens disponiveis
        foreach (var item in availableItems)
        {
            var button = Instantiate(itemSelectButton, transform);
            button.Item = item;
            button.PlayerItems = playerManager.GetCurrentPlayerItems();
        }
    }

    public void ChangePlayer()
    {
        // passa o turno e reseta a tela de selecionar os itens
        playerManager.PassTurn();
        for (var i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Start();
    }
}
