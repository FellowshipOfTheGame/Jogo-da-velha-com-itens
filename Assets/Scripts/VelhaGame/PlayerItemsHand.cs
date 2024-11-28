using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerItemsHand : PlayerItems
{
    [SerializeField] private ItemCard _itemCardPrefab;
    [SerializeField] private PlayerDeck _playerDeck;
    [SerializeField] private ManaManager _manaManager;
    

    private bool _canSelectItem = true;

    private void Start()
    {
        for (var i = 0; i < _maxHandSize; i++)
            DrawCard();
    }
    
    public override void ConfirmItemSelection()
    {
        if (currentSelectedItem is null)
            return;
        Items.Remove(currentSelectedItem);
        DestroyUsedCard();
        _manaManager.ActivateItem(currentSelectedItem.Item);
        
        if (currentSelectedItem.Item.SecondClickEffect)
        {
            currentSelectedItem.Item = currentSelectedItem.Item.SecondClickEffect;
            _canSelectItem = false;
            return;
        }

        _canSelectItem = true;
        currentSelectedItem = null;
        _manaManager.IncreaseMana();
        
        if (Items.Count < _maxHandSize)
            DrawCard();
    }

    public override void ToggleItemSelected(ItemButton item)
    {
        if (!_canSelectItem) return;
        base.ToggleItemSelected(item);
    }

    public bool CanActivateItem() => 
        _manaManager.CanActivateItem(currentSelectedItem.Item);

    private void DestroyUsedCard()
    {
        if (currentSelectedItem.Item.Name != "Jogada comum")
            Destroy(currentSelectedItem.gameObject);
        else
            currentSelectedItem.ToggleItemSelected();
    }

    private void DrawCard()
    {
        var card = Instantiate(_itemCardPrefab, transform).GetComponent<ItemCard>();
        card.Item = _playerDeck.DrawCard();
        card.PlayerItems = this;
        Items.Add(card);
    }

    [FormerlySerializedAs("_startingHandSize")] [SerializeField] private int _maxHandSize = 5;
}
