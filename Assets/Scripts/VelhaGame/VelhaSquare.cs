using System;
using UnityEngine;
using UnityEngine.UI;

public class VelhaSquare : MonoBehaviour
{
    private VelhaBoard _parentBoard;
    
    public bool isProtected;
    
    private SquareState _squareState = SquareState.None;
    public SquareState SquareState
    {
        get => _squareState;
        set
        {
            _squareState = value;
            UpdateSquare();
        }
    }
    
    public void Setup(int x, int y)
    {
        _parentBoard = GetComponentInParent<VelhaBoard>();
        if (_parentBoard == null) throw new Exception("VelhaSquare doesn't have a VelhaBoard parent");
        
        GetComponent<Button>().onClick.AddListener(
            () => ResolveClick(x,y));
    }

    private void ResolveClick(int x, int y)
    {
        _parentBoard.SquareClick(x, y);
    }
    
    private void UpdateSquare()
    {
        var squareImage = gameObject.GetComponent<Image>();
        switch (SquareState)
        {
            case SquareState.X:
                squareImage.color = Color.red;
                break;
            case SquareState.O:
                squareImage.color = Color.blue;
                break;
            case SquareState.Both:
                squareImage.color = Color.magenta;
                break;
            case SquareState.None:
                squareImage.color = Color.white;
                break;
        }
    }
}

[Flags]
public enum SquareState
{
    None = 0,
    X = 1 << 0,
    O = 1 << 1,
    Both = X | O,
}