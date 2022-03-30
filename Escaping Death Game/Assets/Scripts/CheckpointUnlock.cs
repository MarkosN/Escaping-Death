using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUnlock : MonoBehaviour // This script isn't actually enabling the checkpoints as from the beginning they are all enabled
{                                             // It is only enabling the visual part in order to create the illusion that the players unlocking the checkpoints
   
    public GameObject unlockCheckpoint; // The checkpoint sign
    public GameObject unlockChecker;    // Checker in order to enable the checkpoint sign

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            unlockCheckpoint.SetActive(true); // Enable the checkpoint sign
            unlockChecker.SetActive(false);   // Disable the checker that is responsible to enable the checkpoint sign after it had done its job

            //audioManager.TrapsSound(); // Play a sound when the checkpoint is reached
        }
    }
}