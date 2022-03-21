using UnityEngine;

public class KeepMainSounds : MonoBehaviour // Keeping the component that contains the main sounds that are used in every level of the game throughout the scenes
{
    void Awake()
    {
        GameObject[] mainSounds = GameObject.FindGameObjectsWithTag("MainSounds");

        if (mainSounds.Length > 1) // This is when the player "enters" again the scene that there is the component so in order to not have 2 and more to destroy the same extra components and be left with only 1 each time
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}