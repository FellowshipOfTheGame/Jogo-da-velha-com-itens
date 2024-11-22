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


    private VelhaSquare[,] _squares;
    
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
        _dimension = dimension;
        
        var sqsize = CalculateSquareSize(dimension, gap);

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
                
                //Sets size and position of each square
                var squareRectTransform = square.GetComponent<RectTransform>();
                squareRectTransform.sizeDelta = sqsize*Vector2.one;
                squareRectTransform.localPosition = new Vector2(horizontal, vertical);
                
                horizontal += sqsize + gap;
            }
            vertical -= sqsize + gap;
        }
    }

    private float CalculateSquareSize(uint dimension, float gap)
    {
        //BoardSize
        float width = _rectTransform.sizeDelta[0];
        float height = _rectTransform.sizeDelta[1];

        //Calculates the square size
        float sqsize = math.max(
            (width - ((dimension - 1) * gap)) / dimension,
            (height - ((dimension - 1) * gap)) / dimension
        );
        return sqsize;
    }


    //Every Move is Implemented In the Board
    public void SquareClick(int x, int y, ClickEffect.ClickActor clickActor)
    {
        if (_squares[x,y].SquareState != SquareState.None) return;
        
        if (clickActor == ClickEffect.ClickActor.Player1)
            _squares[x,y].SquareState = SquareState.X;
        else if(clickActor == ClickEffect.ClickActor.Player2)
            _squares[x,y].SquareState = SquareState.O;
        
        CheckWin();
        ClickEffect.PassTurn();
    }

    public void Eraser(int x, int y)
    {
        _squares[x,y].SquareState = SquareState.None;
        
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
                    temp[i, j] = _squares[i,j].SquareState;
                else
                    temp[i, j] = SquareState.None;
        
        Setup(_dimension,_gap);

        for (int i = 0; i < _dimension; i++)
            for (int j = 0; j < _dimension; j++)
                if (temp[i, j] != SquareState.None)
                {
                    _squares[i,j].SquareState = temp[i, j];
                }
    }

    public void SetProtected(int x, int y)
    {
        _squares[x, y].isProtected = true;
    }

    private void CheckWin()
    {
        SquareState _checkWin(SquareState last, int i, int j, ref int count)
        {
            last &= _squares[i, j].SquareState;
            if (last == SquareState.None)
            {
                last = _squares[i, j].SquareState;
                count = 1;
            }
            else
                count++;

            if (count == 3)
            {
                Win(last);
            }

            return last;
        }

        for (int i = 0; i < _dimension; i++)
        {
            SquareState last = SquareState.None;
            int count = 0;
            for (int j = 0; j < _dimension; j++)
            {
                last = _checkWin(last, i, j, ref count);
            }
        }

        for (int j = 0; j < _dimension; j++)
        {
            SquareState last = SquareState.None;
            int count = 0;
            for (int i = 0; i < _dimension; i++)
            {
                last = _checkWin(last, i, j, ref count);
            }
        }
    
        for (int k = 0; k < _dimension; k++)
        {
            SquareState last = SquareState.None;
            int count = 0;
            for (int i = k, j = 0; i < _dimension; i++, j++)
            {
                last = _checkWin(last, i, j, ref count);
            }
        }
        
        for (int k = 0; k < _dimension; k++)
        {
            SquareState last = SquareState.None;
            int count = 0;
            for (int i = k, j = 0; i >= 0; i--, j++)
            {
                last = _checkWin(last, i, j, ref count);
            }
        }
    }

    private void Win(SquareState winner)
    {
        Debug.Log(winner);
    }
}
