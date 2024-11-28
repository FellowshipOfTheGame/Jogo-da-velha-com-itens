using Unity.Mathematics;
using UnityEngine;

public class VelhaBoard : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private VictorySceneSwapper sceneSwapper;
    
    private RectTransform _rectTransform;
    public GameObject squarePrefab;

    public VelhaSquare[,] squares;
    
    public int _dimension;
    private int _marksCountForWin = 3; 
    private float _gap = 1.2f;

    private void OnEnable(){
        _rectTransform = transform as RectTransform;
        DrawSquares(3,_gap);
    }

    private bool AccessibleSquare(int x, int y) =>
         x >= 0 && x < _dimension && y >= 0 && y < _dimension;

    private void DrawSquares(int dimension,float gap)
    {
        squares = new VelhaSquare[dimension,dimension];
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
                squares[i, j] = square.GetComponent<VelhaSquare>();
                squares[i, j].Setup(i,j);
                
                //Sets size and position of each square
                var squareRectTransform = square.GetComponent<RectTransform>();
                squareRectTransform.sizeDelta = sqsize*Vector2.one;
                squareRectTransform.localPosition = new Vector2(horizontal, vertical);
                
                horizontal += sqsize + gap;
            }
            vertical -= sqsize + gap;
        }
    }

    private float CalculateSquareSize(int dimension, float gap)
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
    public void SquareClick(int x, int y)
    {
        var playerItems = (PlayerItemsHand)playerManager.GetCurrentPlayerItems();
        ItemBase item = playerItems.currentSelectedItem?.Item;
        if (item is null)
            return;
        
        if (!playerItems.CanActivateItem())
            return;
        
        if (!item.Activate(this, squares[x, y], playerManager.TurnPlayer))
            return;
        playerItems.ConfirmItemSelection();
        
        // tem um segundo efeito a ser resolvido 
        if (playerItems.currentSelectedItem?.Item)
            return;
        
        CheckWin();
        playerManager.PassTurn();
    }

    public void Eraser(int x, int y)
    {
        squares[x,y].SquareState = SquareState.None;
        
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
                if (squares[i, j].isProtected)
                    temp[i, j] = squares[i,j].SquareState;
                else
                    temp[i, j] = SquareState.None;
        
        DrawSquares(_dimension,_gap);

        for (int i = 0; i < _dimension; i++)
            for (int j = 0; j < _dimension; j++)
                if (temp[i, j] != SquareState.None)
                {
                    squares[i,j].SquareState = temp[i, j];
                }
    }

    public void SetProtected(int x, int y)
    {
        squares[x, y].isProtected = true;
    }

    
# region win checking
    private void CheckWin()
    {
        CheckWinHorizontal();
        CheckWinVertical();
        CheckWinPrincipalDiagonal();
        CheckWinSecondaryDiagonal();
    }

    private void CheckWinSecondaryDiagonal()
    {
        for (int k = 0; k < _dimension; k++)
        {
            SquareState last = SquareState.None;
            int count = 0;
            for (int i = k, j = 0; i >= 0; i--, j++)
            {
                last = InnerCheckWin(last, i, j, ref count);
            }
        }
    }

    private void CheckWinPrincipalDiagonal()
    {
        for (int k = 0; k < _dimension; k++)
        {
            SquareState last = SquareState.None;
            int count = 0;
            for (int i = k, j = 0; i < _dimension; i++, j++)
            {
                last = InnerCheckWin(last, i, j, ref count);
            }
        }
    }

    private void CheckWinVertical()
    {
        for (int j = 0; j < _dimension; j++)
        {
            SquareState last = SquareState.None;
            int count = 0;
            for (int i = 0; i < _dimension; i++)
            {
                last = InnerCheckWin(last, i, j, ref count);
            }
        }
    }

    private void CheckWinHorizontal()
    {
        for (int i = 0; i < _dimension; i++)
        {
            SquareState last = SquareState.None;
            int count = 0;
            for (int j = 0; j < _dimension; j++)
            {
                last = InnerCheckWin(last, i, j, ref count);
            }
        }
    }

    private SquareState InnerCheckWin(SquareState last, int i, int j, ref int count)
    {
        last &= squares[i, j].SquareState;
        if (last == SquareState.None)
        {
            last = squares[i, j].SquareState;
            count = 1;
        }
        else
            count++;

        if (count == _marksCountForWin)
        {
            Win(last);
        }

        return last;
    }
    
    #endregion

    private void Win(SquareState winner)
    {
        sceneSwapper.FinishGame(winner == SquareState.X ? Player.X : Player.O);
    }
}
