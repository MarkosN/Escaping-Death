using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Enabling Script to be called from Anothers
    private static AudioManager inst = null;

    public static AudioManager GetAudioManager()
    {
        return inst;
    }

    public void Awake()
    {
        inst = this;
    }

    private AudioSource trapSound, jumpSound, dashSound, buttonSound; // All the Sounds Effects the game has on the main levels

    void Start()
    {
        // Sound Effects List and their Settings
        AudioSource[] soundsList = GetComponents<AudioSource>();

        trapSound = soundsList[0];
        trapSound.volume = 1.0f;
        SoundsSettings(trapSound);

        jumpSound = soundsList[1];
        jumpSound.volume = 1.0f;
        SoundsSettings(jumpSound);

        dashSound = soundsList[2];
        dashSound.volume = 1.0f;
        SoundsSettings(dashSound);

        buttonSound = soundsList[3];
        buttonSound.volume = 1.0f;
        SoundsSettings(buttonSound);
    }

    public void SoundsSettings(AudioSource current) // Sound Effects Settings
    {
        current.loop = false;
    }

    public void TrapsSound() // Play Function for the Trap Contact Sound Effect
    {
        trapSound.Play();
    }

    public void JumpingSound() // Play Function for the Jumping Sound Effect
    {
        jumpSound.Play();
    }

    public void DashingSound() // Play Function for the Dash Sound Effect
    {
        dashSound.Play();
    }

    public void ButtonsSound() // Play Function for the Buttons Sound Effect
    {
        buttonSound.Play();
    }
}