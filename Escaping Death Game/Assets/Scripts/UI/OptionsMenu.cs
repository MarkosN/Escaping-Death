using UnityEngine;

public class OptionsMenu : MonoBehaviour // Options Menu Script and Enable or Disable the Mouse Cursor
{
    public GameObject optionsMenuCanvas;

    void Start()
    {
        // User Won't See the Mouse Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Pause Menu will Open and Close with the Same Button
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (optionsMenuCanvas.gameObject.activeInHierarchy == false) // Options Menu will be Created inside an Additional Canvas so the Script will Enable or Disable the Canvas thus Making the Options Menu to Appear or Not
        {
            // Options Menu is Active
            optionsMenuCanvas.gameObject.SetActive(true); 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Options Menu is Not Active
            optionsMenuCanvas.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Resume() // Used in order to close the Options Menu from the X window button
    {
        optionsMenuCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}