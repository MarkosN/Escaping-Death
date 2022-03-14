using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStoryEnabler : MonoBehaviour // Start Story Manager
{
    public float changeSceneTime; // How much time has to passed in order to tranfer the plyaer to level 1

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame() // After the start scene the player will be tranfered directly to the level 1 of the game
    {
        yield return new WaitForSeconds(changeSceneTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}