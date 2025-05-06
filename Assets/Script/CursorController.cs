using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        Cursor.SetCursor(crosshairTexture, hotspot, cursorMode);
    }
}
