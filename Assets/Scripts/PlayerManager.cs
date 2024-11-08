using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player TurnPlayer { get; private set; }

    public void PassTurn()
    {
        TurnPlayer = TurnPlayer == Player.X ? Player.O : Player.X;
    }
}

public enum Player
{
    X,
    O
} 
