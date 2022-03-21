using UnityEngine;

public class TrapDamage : MonoBehaviour // Traps won't do any real damage to the players only to "transform" them to start from the beginning or from the latest checkpoint (This is the game's traps punish variable)
{
    public CameraShake cameraShake; // In order to access the camera shake variable from the camera shake script
    public GameObject resetArea; // Reset area could be the start or the checkpoint of the level depending on where the player is
    private GameObject playerGO;
    public Rigidbody2D playerRB;

    // Calling the Audio Manager Script
    private AudioManager audioManager;

    void Start()
    {
        playerGO = GameObject.Find("Player"); // In order to assign it automatically in each

        audioManager = AudioManager.GetAudioManager();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            cameraShake.ShakeEnabled(); // When the players contact a trap, a camera shake will appear in order to strengthen the trap damage/punish effect

            playerRB.velocity = new Vector2(0, 0); // After the Player Respawns he Doesn't Inherit any Previous Values on X and Y Axis
            playerGO.transform.position = resetArea.transform.position; // Player will transform to the reset area

            audioManager.TrapsSound();
        }
    }
}