using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridCellView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image cellImage;

    [SerializeField] private Sprite none;

    private GomokuBoard board;
    private int x;
    private int y;


    public void Initialize(GomokuBoard board, int x, int y)
    {
        this.board = board;
        this.x = x;
        this.y = y;

        Refresh(CellType.None, false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        board.Set(x, y);
    }

    public void Refresh(CellType type)
    {
        Refresh(type, false);
    }

    public void Refresh(CellType type, bool isMarkedEmpty)
    {
        if (cellImage != null)
        {
            cellImage.color = CellColorUtility.ToUnityColor(type);
        }
    }
   
}
