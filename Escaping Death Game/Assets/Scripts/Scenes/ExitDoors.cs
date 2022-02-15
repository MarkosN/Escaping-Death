using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoors : MonoBehaviour // This script is responsible for the Exit Door of each level. Exit Doors will transfer the player to the next level.
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player") // When the door contacts the player
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}