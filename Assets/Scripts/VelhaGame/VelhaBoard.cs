using System;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class VelhaBoard : MonoBehaviour
{
    private RectTransform rectTransform;
    public GameObject squarePrefab;

    public enum SquareState{
        Player1,
        Player2,
        None,
        Busy
    }

    private GameObject[,] _squares; 
    private SquareState[,] _squareStates;

    private void OnEnable(){
        rectTransform = transform as RectTransform;
        Setup(3,1.1f);
    }

    void Setup(uint dimension,float gap)
    {
        _squares = new GameObject[dimension,dimension];
        _squareStates = new SquareState[dimension,dimension];
        
        //BoardSize
        float width = rectTransform.sizeDelta[0];
        float height = rectTransform.sizeDelta[1];
        
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
                _squares[i, j] = square;
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

    private void UpdateSquare(int x, int y)
    {
        var squareImage = _squares[x, y]?.GetComponent<Image>();
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
