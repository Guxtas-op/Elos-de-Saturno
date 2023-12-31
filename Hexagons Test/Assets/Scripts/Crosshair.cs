using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnDestroy()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}