using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CursorType
{
    ClosedHand,
    OpenHand
}
public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CursorManager instance;


    public Texture2D openHand, closedHand;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void SetCursor(CursorType type)
    {
        //if (type == CursorType.ClosedHand)
        //{
        //    Cursor.SetCursor(closedHand, new Vector2(400, 0), CursorMode.Auto);
        //}
        //else
        //{
        //    Cursor.SetCursor(openHand, new Vector2(400, 0), CursorMode.Auto);
        //}
    }
}
