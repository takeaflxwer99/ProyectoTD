using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratonchuli : MonoBehaviour
{

    //Settings.
    [Header("Settings")]
    public bool custom_cursor;

    //References.
    [Tooltip("Set as sprite in import settings. Enable Read/Write")]
    public Texture2D cursor_texture;
    [Tooltip("Set the input point of your cursor.")]
    public Vector2 cursor_hotspot = Vector2.zero;
    CursorMode cursor_mode = CursorMode.Auto;



    void Start()
    {

        SetCustomCursor();

    }


    //If custom_cursor is checked, load custom cursor texture.
    void SetCustomCursor()
    {

        if (custom_cursor)
        {

            Cursor.SetCursor(cursor_texture, cursor_hotspot, cursor_mode);

        }

    }


}
