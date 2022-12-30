using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Sprite cursor;
    void Start()
    {
        Cursor.SetCursor(cursor.texture,Vector2.zero,CursorMode.ForceSoftware);
    }
}
