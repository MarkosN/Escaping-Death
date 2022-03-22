using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour // Buttons Manager for Main and Pause Menu
{
    public void StartGame() // Button to Give the Player the Ability to Start the Game
    {
        SceneManager.LoadScene("Loading Scene");
    }

    public void ReturnToMainMenu() // Button to Give the Player the Ability to Return to Main Menu
    {
        SceneManager.LoadScene("Loading Scene0");
    }

    public void Exit() // Button to Give the Player the Ability to Exit the Game
    {
        Application.Quit();
    }
}