using UnityEngine;

public static class CellColorUtility
{
    public static readonly Color EmptyColor = new Color(0.76f, 0.56f, 0.32f,0f);
    public static readonly Color White = new Color(0.96f, 0.96f, 0.92f);
    public static readonly Color Black = new Color(0.16f, 0.18f, 0.22f);

    public static Color ToUnityColor(CellType type)
    {
        switch (type)
        {
            case CellType.Black:
                return Black;
            case CellType.White:
                return White;
            default:
                return EmptyColor;
        }
    }
}
