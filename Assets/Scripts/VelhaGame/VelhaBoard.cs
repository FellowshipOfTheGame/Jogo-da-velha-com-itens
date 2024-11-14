using System;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class VelhaBoard : MonoBehaviour
{
    private RectTransform _rectTransform;
    public GameObject squarePrefab;

    public enum SquareState
    {
        Player1,
        Player2,
        None,
        Busy
    }

    private VelhaSquare[,] _squares; 
    private SquareState[,] _squareStates;
    
    private uint _dimension;
    private float _gap = 1.2f;

    private void OnEnable(){
        _rectTransform = transform as RectTransform;
        Setup(3,_gap);
    }

    private bool AccessibleSquare(int x, int y) =>
         x >= 0 && x < _dimension && y >= 0 && y < _dimension;

    void Setup(uint dimension,float gap)
    {
        _squares = new VelhaSquare[dimension,dimension];
        _squareStates = new SquareState[dimension,dimension];

        _dimension = dimension;
        
        //BoardSize
        float width = _rectTransform.sizeDelta[0];
        float height = _rectTransform.sizeDelta[1];
        
        //Calculates the square size
        float sqsize = math.max(
            (width-((dimension-1)*gap))/dimension,
            (height-((dimension-1)*gap))/dimension
            );
        
        //Initiates every square in the tic-tac-toe
        float vertical = -sqsize;
        for(int i = 0; i < dimension; i++){
            float horizontal = 0;
            for(int j = 0; j < dimension; j++){
                //Instantiate square
                var square = Instantiate(squarePrefab,transform);
                
                //Sets Square Up
                square.GetComponent<VelhaSquare>().Setup(i,j);
                _squares[i, j] = square.GetComponent<VelhaSquare>();
                _squareStates[i,j] = SquareState.None;
                
                //Sets size and position of each square
                var squareRectTransform = square.GetComponent<RectTransform>();
                squareRectTransform.sizeDelta = sqsize*Vector2.one;
                squareRectTransform.localPosition = new Vector2(horizontal, vertical);
                
                horizontal += sqsize + gap;
            }
            vertical -= sqsize + gap;
        }
    }

    
    //Every Move is Implemented In the Board
    public void SquareClick(int x, int y, ClickEffect.ClickActor clickActor)
    {
        if (_squareStates[x,y] != SquareState.None) return;
        if (clickActor == ClickEffect.ClickActor.Player1)
            _squareStates[x, y] = SquareState.Player1;
        else if(clickActor == ClickEffect.ClickActor.Player2)
                _squareStates[x, y] = SquareState.Player2;
        
        UpdateSquare(x,y);
        ClickEffect.PassTurn();
    }

    public void Eraser(int x, int y)
    {
        _squareStates[x,y] = SquareState.None;
        UpdateSquare(x,y);
        
        //TODO Turn passes?
        //ClickEffect.ClickActor();
    }
    
    public void Diluvium()
    {
        int n = transform.childCount;
        for (int i = 0; i < n; i++)
            Destroy(transform.GetChild(i).gameObject);
        
        SquareState[,] temp = new SquareState[_dimension,_dimension];
        for (int i = 0; i < _dimension; i++)
            for (int j = 0; j < _dimension; j++)
                if (_squares[i, j].isProtected)
                    temp[i, j] = _squareStates[i, j];
                else
                    temp[i, j] = SquareState.None;
        
        Setup(_dimension,_gap);

        for (int i = 0; i < _dimension; i++)
            for (int j = 0; j < _dimension; j++)
            if (temp[i, j] != SquareState.None)
            {
                _squareStates[i,j] = temp[i, j];
                UpdateSquare(i,j);
            }
    }

    public void SetProtected(int x, int y)
    {
        _squares[x, y].isProtected = true;
        UpdateSquare(x,y);
    }

    private void UpdateSquare(int x, int y)
    {
        var squareImage = _squares[x, y].gameObject.GetComponent<Image>();
        switch (_squareStates[x, y])
        {
            case SquareState.Player1:
                squareImage.color = Color.red;
                break;
            case SquareState.Player2:
                squareImage.color = Color.blue;
                break;
            case SquareState.None:
            case SquareState.Busy:
                squareImage.color = Color.white;
                break;
        }
    }
}
