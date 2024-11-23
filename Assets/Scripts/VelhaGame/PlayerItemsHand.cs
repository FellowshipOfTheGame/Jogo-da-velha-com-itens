using System;
using UnityEngine;

public class PlayerItemsHand : PlayerItems
{
    [SerializeField] private ItemCard _itemCardPrefab;
    [SerializeField] private PlayerDeck _playerDeck;

    private void Start()
    {
        for (var i = 0; i < _startingHandSize; i++)
        {
            DrawCard();
        }
        
    }

    private void DrawCard()
    {
        var card = Instantiate(_itemCardPrefab, transform).GetComponent<ItemCard>();
        card.Item = _playerDeck.DrawCard();
        card.PlayerItems = this;
        Items.Add(card);
    }

    [SerializeField] private int _startingHandSize = 5;
}
