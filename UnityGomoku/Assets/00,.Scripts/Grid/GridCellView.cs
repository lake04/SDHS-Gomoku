using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridCellView : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Image cellImage;

    private GomokuBoard board;
    private int x;
    private int y;

    public void Initialize(GomokuBoard board, int x, int y)
    {
        this.board = board;
        this.x = x;
        this.y = y;

        Set(CellType.None);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        board.Set(x, y);
    }


    public void Set(CellType type)
    {
        if (cellImage != null)
        {
            cellImage.color = CellColorUtility.ToUnityColor(type);
        }
    }
}
