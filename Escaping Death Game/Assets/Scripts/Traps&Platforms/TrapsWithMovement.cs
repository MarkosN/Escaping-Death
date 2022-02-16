using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsWithMovement : MonoBehaviour // For the Up/Down Blocks Traps, Up/Down Nails Traps, Moving Platforms and Left/Right Traps
{
	// Traps or Platforms will Move between Two Points in the world
	private Vector2 startPosition;
	private Vector2 newPosition;

	public float speed;       // Traps or Platforms Speed While they are Moving
	public float maxDistance; // Distance that the Traps or Platforms will Cover

	// Depending which is true it will decide in which axis the traps or platforms will move
	public bool moveXaxis;
	public bool moveYaxis;

	void Start()
	{
		startPosition = transform.position; // Start
		newPosition = transform.position;   // End
	}

	void FixedUpdate()
	{
		if (moveXaxis == true & moveYaxis== false)
        {
			newPosition.x = startPosition.x + (maxDistance * Mathf.Cos(Time.time * speed)); // Making the Traps or Platforms to Move Up and Down or Left and Right Continuously
			transform.position = newPosition;
		}
		if (moveYaxis == true & moveXaxis == false)
		{
			newPosition.y = startPosition.y + (maxDistance * Mathf.Cos(Time.time * speed)); //  Making the Traps or Platforms to Move Up and Down or Left and Right Continuously
			transform.position = newPosition;
		}
	}
}