using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<ItemBase> availableItems;
    [SerializeField] private ItemSelectButton itemSelectButton;
    [SerializeField] private PlayerManager playerManager;
    private PlayerItems currentPlayerItems;
    private bool firstPlayerFinished;
    private void Start()
    {
        currentPlayerItems = playerManager.GetCurrentPlayerItems();
        var selectedItems = currentPlayerItems.ConfirmedItems.Select(i => i.Item.Name).ToArray();
        // criar o botoes para selecionar os itens a partir dos itens disponiveis
        foreach (var item in availableItems)
        {
            if (selectedItems.Contains(item.Name))
            {
                // ignora os items selecionados
                continue;
            }
            var button = Instantiate(itemSelectButton, transform);
            button.Item = item;
            button.PlayerItems = currentPlayerItems;
        }
    }

    public void ConfirmSelection()
    {
        // passa o turno e reseta a tela de selecionar os itens
        currentPlayerItems.ConfirmItemSelection();
        if (!firstPlayerFinished)
        {
            playerManager.PassTurn();
        }
        for (var i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Start();
    }
    
    public void FinishSelection()
    {
        if (firstPlayerFinished)
        {
            // passar para a proxima cena
            return;
        }

        firstPlayerFinished = true;
        playerManager.PassTurn();
        for (var i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Start();
    }
}
