using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public ItemBase[] AvailableItems;

    public ItemBase DrawCard()
    {
        return AvailableItems[Random.Range(0, AvailableItems.Length)];
    }
}
