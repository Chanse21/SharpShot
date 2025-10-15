using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Unlock the cursor

        Cursor.lockState = CursorLockMode.None;

        // Make the cursor visible

        Cursor.visible = true;
    }

}