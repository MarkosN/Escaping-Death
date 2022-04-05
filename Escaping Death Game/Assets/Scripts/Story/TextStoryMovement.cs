using UnityEngine;

public class TextStoryMovement : MonoBehaviour // In order to control the speed and direction of the story text (how it will be appeared on the player)
{
    public GameObject textStory; // Story Text from the canvas
    public float textSpeed; // Story's Text Speed

    // Update is called once per frame
    void FixedUpdate()
    {
        textStory.transform.Translate(Vector2.up * textSpeed * Time.deltaTime);  // Text Moves Up Continuously
    }
}