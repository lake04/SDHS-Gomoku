using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GomokuBoard : MonoBehaviour
{
    [SerializeField] private int width = 15;
    [SerializeField] private int height = 15;

    private GridCell[,] grid;
    private GridCellView[,] gridView;
    [SerializeField] private GridCellView stonePrefab;

    private GameState gameState = GameState.Black;
    [SerializeField] private GameObject gameShowState;
    [SerializeField] private TMP_Text gameShowText;
    [SerializeField] private Button restartBtn;

    [SerializeField] private TMP_Text gameStateText;


    private Vector2Int[] around = new Vector2Int[4]
    {
       new Vector2Int(1, 0),
       new Vector2Int(0, 1),
       new Vector2Int(1, 1),
       new Vector2Int(1, -1)
    };

    void Start()
    {
        gameShowState.SetActive(false);

        grid = new GridCell[width, height];
        gridView = new GridCellView[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid[x, y] = new GridCell();
                CreateCellView(x, y);
            }
        }

        restartBtn.onClick.AddListener(Restart);

    }

    public void Set(int x, int y)
    {
        GridCell cell = grid[x, y];

        CellType cellType = cell.CurType;

        if(cellType != CellType.None || gameState == GameState.End)
        {
            return;
        }

        switch(gameState)
        {
            case GameState.Black:
                cellType = CellType.Black;
                break;
            case GameState.White:
                cellType = CellType.White;
                break;
        }

       if (cellType == CellType.Black && IsOverline(x, y))
       {
            Debug.Log("Overline");
            return;
       }

        cell.SetType(cellType);
        gridView[x, y].Set(cell.CurType);

       if (Check(x, y, cellType))
       {
           Debug.Log("Game End");
           GameEnd();
           gameState = GameState.End;
           return;
       }
       
       if(IsFullGrid())
       {
           GameDraw();
           gameState = GameState.End;
           return;
       }

        ChangeState();
    }

    private void CreateCellView(int x, int y)
    {
        GridCellView cellView = Instantiate(stonePrefab, transform);
        cellView.Initialize(this, x, y);
        gridView[x, y] = cellView;
    }

    private bool IsOverline(int startX, int startY)
    {
        foreach (Vector2Int direction in around)
        {
            int sequence = 1;

            sequence += CountSequence(startX, startY, direction, CellType.Black);

            sequence += CountSequence(startX, startY, -direction, CellType.Black);

            if (sequence >= 6)
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckRenju(int startX, int startY)
    {
        foreach (Vector2Int direction in around)
        {
            CountThree(startX, startY,direction);
        }


        return false;
    }

    private bool IsDoubleThree(int startX, int startY)
    {
        return false;
    }

    private bool IsDoubleFour(int startX, int startY)
    {
        return false;
    }

    private int CountThree(int startX, int startY, Vector2Int dir)
    {
        int count = 0;

        
        return count;
    }

    private int CountFour(int startX, int startY)
    {
        return 0;
    }

    private bool IsThree(int startX, int startY, Vector2Int direction)
    {
        return false;
    }

    private bool IsOpenFour(int startX, int startY, Vector2Int direction)
    {
        return false;
    }

    private int CountWinningPosition(int startX, int startY, Vector2Int direction)
    {
        return 0;
    }

    private bool IsFive(int startX, int startY, Vector2Int direction)
    {
        return CountLineSequence(startX, startY, direction, CellType.Black) == 5;
    }

    public bool Check(int startX, int startY, CellType curType)
    {
        foreach (Vector2Int direction in around)
        {
            int sequence = CountLineSequence(startX, startY, direction, curType);

            if (curType == CellType.Black && sequence == 5)
            {
                return true;
            }

            if (curType == CellType.White && sequence >= 5)
            {
                return true;
            }
        }

        return false;
    }

    private int CountLineSequence(int startX, int startY, Vector2Int direction, CellType curType)
    {
        int sequence = 1;

        sequence += CountSequence(startX, startY, direction, curType);
        sequence += CountSequence(startX, startY, -direction, curType);

        return sequence;
    }

    private int CountSequence(int startX, int startY, Vector2Int dir, CellType curType)
    {
        int count = 0;
        int x = startX + dir.x;
        int y = startY + dir.y;

        while (InBoard(x, y) && grid[x, y].CurType == curType)
        {
            count++;
            x += dir.x;
            y += dir.y;
        }

        return count;
    }

    private bool InBoard(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    private bool IsFullGrid()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x,y].CurType == CellType.None)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool TrySet()
    {
        return false;
    }

    private void ChangeState()
    {
        if(gameState == GameState.Black)
        {
            gameState = GameState.White;
        }
        else if(gameState == GameState.White)
        {
            gameState = GameState.Black;
        }

        gameStateText.text = gameState.ToString();
    }

    private void GameEnd()
    {
        if (gameState == GameState.Black)
        {
            gameShowText.text = "BlackWin";

        }
        else if (gameState == GameState.White)
        {
            gameShowText.text = "WhiteWin";
        }
        gameShowState.SetActive(true);
    }

    private void GameDraw()
    {
        gameShowText.text = "Draw";
        gameShowState.SetActive(true);
    }

    private void Restart()
    {
        gameState = GameState.Black;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid[x, y].SetType(CellType.None);
                gridView[x, y].Set(CellType.None);
            }
        }
        gameStateText.text = gameState.ToString();
        gameShowState.SetActive(false);
    }
}
