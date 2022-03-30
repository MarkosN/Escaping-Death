using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipStoryScenes : MonoBehaviour // In order for the players to be able to skip the storyline scenes
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) // Players can go to the next scene by pressing any key/button
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}