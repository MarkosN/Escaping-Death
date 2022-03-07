using System.Collections;
using UnityEngine;

public class DisableDarkIntro : MonoBehaviour // Dark Intro will be a black image which will fade out in the beginning of each level
{
    public GameObject darkIntro; // Dark Intro will be in on the start of every level

    void Awake()
    {
        StartCoroutine(DarkIntroDisable());
    }

    IEnumerator DarkIntroDisable()
    {
        yield return new WaitForSeconds(1.0f); // Depending the duration of the dark intro's animation
        darkIntro.SetActive(false); // Disable it after it is played in order to not cause problem with the pause/options menu of the game
    }
}