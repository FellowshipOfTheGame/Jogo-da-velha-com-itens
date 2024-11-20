using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<ItemBase> availableItems;
    [SerializeField] private ItemSelectButton itemSelectButton;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private SceneSwapper sceneSwapper;
    
    private PlayerItems currentPlayerItems;
    private bool firstPlayerFinished;
    private void Start()
    {
        currentPlayerItems = playerManager.GetCurrentPlayerItems();
        var selectedItems = currentPlayerItems.Items.Select(i => i.Item.Name).ToArray();
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
        if (currentPlayerItems is null)
            return;
        
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
            sceneSwapper.FinishItemSelection();
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
