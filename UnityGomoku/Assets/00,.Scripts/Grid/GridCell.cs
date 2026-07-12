using UnityEngine;

public class GridCell
{
    public CellType CurType { get; private set; }

    public GridCell()
    {
        CurType = CellType.None;
    }

    public void SetColor(CellType type)
    {
        CurType = type;
    }
}
