using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player TurnPlayer { get; private set; }
    [SerializeField] private PlayerItems XPlayerItems;
    [SerializeField] private PlayerItems OPlayerItems;
    
    public void PassTurn()
    {
        TurnPlayer = TurnPlayer == Player.X ? Player.O : Player.X;
    }

    public PlayerItems GetCurrentPlayerItems() =>
        TurnPlayer == Player.X ? XPlayerItems : OPlayerItems;
}

public enum Player
{
    X,
    O
} 
