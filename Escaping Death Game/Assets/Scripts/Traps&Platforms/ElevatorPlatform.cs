using UnityEngine;

public class ElevatorPlatform : MonoBehaviour // For the Elevator Platform
{
	// The elevator platform will move continuously up in the world
	private Vector2 startPosition;
	private Vector2 currentPosition;

	public float speed; // Elevator platform's Speed While it is Moving

	void Start()
	{
		startPosition = transform.position; // Start
	}

	void FixedUpdate()
	{
		currentPosition.y = startPosition.y + Time.time * speed; // Making the elevator platform to Move Up Continuously
		transform.position = currentPosition;
	}
}