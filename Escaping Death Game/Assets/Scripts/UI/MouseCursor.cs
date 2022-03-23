using UnityEngine;

public class MouseCursor : MonoBehaviour // Enable the Mouse Cursor on the Main Menu
{
    void Start()
    {
        // User Can See the Mouse Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}