using System;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UI;

public class VelhaSquare : MonoBehaviour
{
    private (int x, int y) _coordenates;
    private VelhaBoard _parentBoard;
    private bool _isExpanded;
    
    public bool isProtected;
    
    public void Setup(int x, int y)
    {
        _parentBoard = GetComponentInParent<VelhaBoard>();
        if (_parentBoard == null) throw new Exception("VelhaSquare doesn't have a VelhaBoard parent");
        
        _coordenates = (x, y);
        GetComponent<Button>().onClick.AddListener(
            () => ResolveClick(x,y));
    }

    private void ResolveClick(int x, int y)
    {
        ClickEffect.ClickEffectType mode = ClickEffect.GetCurrSelectionMode();
        
        switch (mode){
            case ClickEffect.ClickEffectType.NormalClick:
                _parentBoard.SquareClick(x,y,ClickEffect.GetCurrPlayer());
                break;
            case ClickEffect.ClickEffectType.Eraser:
                _parentBoard.Eraser(x,y);
                break;
            case ClickEffect.ClickEffectType.Protect:
                _parentBoard.SetProtected(x, y);
                break;
            
        }
        
        ClickEffect.ResetSelectionMode();
    }

    private void Expand()=>
        throw new NotImplementedException();

    private void Collapse()=>
        throw new NotImplementedException();
}
