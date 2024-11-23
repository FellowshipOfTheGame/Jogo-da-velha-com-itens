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
        return;
        // ClickEffect.ClickEffectType mode = ClickEffect.GetCurrSelectionMode();
        //
        // switch (mode){
        //     case ClickEffect.ClickEffectType.NormalClick:
        //         _parentBoard.SquareClick(x,y,ClickEffect.GetCurrPlayer());
        //         break;
        //     case ClickEffect.ClickEffectType.Eraser:
        //         _parentBoard.Eraser(x,y);
        //         break;
        //     case ClickEffect.ClickEffectType.Protect:
        //         _parentBoard.SetProtected(x, y);
        //         break;
        //     
        // }
        //
        // ClickEffect.ResetSelectionMode();
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
            case SquareState.None:
            case SquareState.Both:
                squareImage.color = Color.white;
                break;
        }
    }

    private void Expand()=>
        throw new NotImplementedException();

    private void Collapse()=>
        throw new NotImplementedException();
}

[Flags]
public enum SquareState
{
    None = 0,
    X = 1 << 0,
    O = 1 << 1,
    Both = X | O,
}