using UnityEngine;

public class GomokuBoard : MonoBehaviour
{
    [SerializeField] private int width = 15;
    [SerializeField] private int height = 15;

    private GridCell[,] grid;
    private GridCellView[,] gridView;
    [SerializeField] private GridCellView cellPrefab;

    private GameState gameState;

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

    void Update()
    {
        
    }

    private void CreateCellView(int x, int y)
    {
        if (cellPrefab == null)
        {
            return;
        }

        Transform parent = transform;
        GridCellView cellView = Instantiate(cellPrefab, parent);
        cellView.Initialize(this, x, y);
        gridView[x, y] = cellView;
    }

    public void Set(int x, int y)
    {
        GridCell cell = grid[x, y];

        CellType cellType = CellType.None;
        switch(gameState)
        {
            case GameState.Black:
                cellType = CellType.Black;
                break;
            case GameState.White:
                cellType = CellType.White;
                break;
        }

        cell.SetColor(cellType);

        gridView[x, y].Refresh(cell.CurType);
    }
}
