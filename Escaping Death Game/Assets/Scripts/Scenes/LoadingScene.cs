using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour // Responsible about the time it will take to go from loading to the next scene
{
    public bool yesNextScene; // For when there is a next scene on the build settings
    public bool noNextScene;  // For when there is NOT a next scene on the build settings (Main Menu Scene)

    private float randomSec; // The seconds that it will take from the loading scene to the next scene will be random but with limits

    private void Awake()
    {
        randomSec = Random.Range(3, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (yesNextScene == true && noNextScene == false)
        {
            StartCoroutine(NextSceneSeconds1());
        }
        else if (noNextScene== true && yesNextScene == false)
        {
            StartCoroutine(NextSceneSeconds2());
        }
    }

    IEnumerator NextSceneSeconds1() // Transfer to Next Scene
    {
        yield return new WaitForSeconds(randomSec);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator NextSceneSeconds2() // Transfer to Main Menu
    {
        yield return new WaitForSeconds(randomSec);
        SceneManager.LoadScene("Main Menu");
    }
}