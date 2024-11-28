using System;
using TMPro;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    [SerializeField] private int _mana = 5;
    [SerializeField] private int _maxMana = 10;
    private TextMeshProUGUI text;
    
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        UpdateManaCounter();
    }

    public bool CanActivateItem(ItemBase item) => item.Cost <= _mana;

    public void ActivateItem(ItemBase item)
    {
        _mana -= item.Cost;
        UpdateManaCounter();
    }

    public void IncreaseMana(int amount = 1)
    {
        if (_mana < _maxMana)
            _mana += amount;
        else
            _mana = _maxMana;
        UpdateManaCounter();
    }

    private void UpdateManaCounter()
    {
        text.text = _mana.ToString();
    }
}
