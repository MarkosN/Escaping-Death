using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStoryEnabler : MonoBehaviour // Start Story Manager
{
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame() // After the start scene the player will be tranfered directly to the level 1 of the game
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}