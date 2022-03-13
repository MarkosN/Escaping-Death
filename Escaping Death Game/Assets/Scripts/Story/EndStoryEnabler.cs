using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStoryEnabler : MonoBehaviour // End Story Manager
{
    public GameObject cowboyOld; // Dead Cowboy Sprite
    public GameObject cowboyNew; // Alive (Wake Up) Cowboy Sprite

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WakeUpCowboy());
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator WakeUpCowboy() // Enable the Alive cowboy anmd disable the dead one
    {
        yield return new WaitForSeconds(6.5f);
        cowboyOld.SetActive(false);
        cowboyNew.SetActive(true);
    }

    IEnumerator ReturnToMenu() // After the end scene the player will be tranfered directly to the main menu of the game
    {
        yield return new WaitForSeconds(8.0f);
        SceneManager.LoadScene("Main Menu");
    }
}