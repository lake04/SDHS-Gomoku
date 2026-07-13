using UnityEngine;

public class GomokuBoard : MonoBehaviour
{
    [SerializeField] private int width = 15;
    [SerializeField] private int height = 15;

    private GridCell[,] grid;
    private GridCellView[,] gridView;
    [SerializeField] private GridCellView stonePrefab;

    private GameState gameState = GameState.Black;

    void Start()
    {
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
    }

    public void Set(int x, int y)
    {
        GridCell cell = grid[x, y];

        CellType cellType = cell.CurType;

        if(cellType != CellType.None)
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

        cell.SetType(cellType);

        gridView[x,y].Set(cell.CurType);

        ChangeState();
    }

    private void CreateCellView(int x, int y)
    {
        GridCellView cellView = Instantiate(stonePrefab, transform);
        cellView.Initialize(this, x, y);
        gridView[x, y] = cellView;
    }

    public bool Check(int startX, int startY)
    {
        for (int y = startY - 4; y < startY + 4; y++)
        {
            for (int x = startX - 4; x < startX + 4; x++)
            {
                //ºñ±³
            }
        }

        Debug.Log("Gomoku");
        return true;
    }

    private bool InBoard(int x, int y)
    {
        return x >= 0 && x < width &&  y >= 0 && y < height;
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
    }
}
