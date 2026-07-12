using UnityEngine;

public class GomokuBoard : MonoBehaviour
{
    [SerializeField] private int width = 15;
    [SerializeField] private int height = 15;

    private GridCell[,] grid;
    private GridCellView[,] gridView;

    void Start()
    {
        grid = new GridCell[width, height];
        gridView = new GridCellView[width, height];

        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                gridView[i, j].Initialize(this, i, j);
            }
        }
    }

    void Update()
    {
        
    }

    public void Set(int x, int y)
    {
        GridCell cell = grid[x, y];

        //cell.SetColor();

        gridView[x, y].Refresh(cell.CurType);
    }
}
