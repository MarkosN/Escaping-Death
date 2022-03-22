using UnityEngine;

public class OptionsMenu : MonoBehaviour // Options Menu Script and Enable or Disable the Mouse Cursor
{
    public Transform optionsMenuCanvas;

    private int num = 1; // Using this so i Can Use the Same Button For Enable/Disable the Mouse Cursor

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

        if (Input.GetKeyDown(KeyCode.Escape) && (num % 2) == 1) // User Can Now See the Mouse Cursor
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            num += 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && (num % 2) == 0) // User Can Not See the Mouse Cursor Now
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            num -= 1;
        }
    }

    public void Pause()
    {
        if (optionsMenuCanvas.gameObject.activeInHierarchy == false) // Options Menu will be Created inside an Additional Canvas so the Script will Enable or Disable the Canvas thus Making the Options Menu to Appear or Not
        {
            optionsMenuCanvas.gameObject.SetActive(true); // Otpions Menu is Active
        }
        else
        {
            optionsMenuCanvas.gameObject.SetActive(false); // Options Menu is Not Active
        }
    }
}