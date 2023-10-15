using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using static UnityEditor.Progress;


public enum CursorType
{
    ClosedHand,
    OpenHand
}
public class CursorManager : Singleton<CursorManager>
{
    public Texture2D openHand, closedHand;

    public void SetCursor(CursorType type)
    {
        if (type == CursorType.ClosedHand)
        {
            Cursor.SetCursor(closedHand, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(openHand, Vector2.zero, CursorMode.Auto);
        }
    }

    public void ShowCursor(bool value)
    {
        Cursor.visible = value;
    }
}
