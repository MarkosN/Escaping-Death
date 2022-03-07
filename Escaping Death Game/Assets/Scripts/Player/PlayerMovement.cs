using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour // This script contains the player's complete movement system
{
	private Rigidbody2D player;

	public float playerSpeed;             // Player's speed
	public float jumpForce;               // Player's jump force
	public float dashForce;               // Player's dash force
	public float smoothMovement;          // Smoothing the beginning and ending of the movement
	private float groundedRadius = 0.20f; // Radius of the overlap circle to determine if grounded
	private float horizontalMove = 0f;    // Player starts still

	private bool airControlling = true;   // Giving the option for the players to move the character while they are on the air
	private bool grounded;                // If the player is grounded or not
	private bool faceRightSide = true;    // Which side the player is facing (starting with the right side)
	private bool jump = false;            // In order to check when the players can jump
	private bool dash = false;            // In order to check when the players can dash

	private Vector3 velocity = Vector3.zero; // Player's velocity
	public LayerMask ground;                 // Everything is ground for the player except from the character
	public Transform jumpCheck;              // Checking if the player can jump

	public Animator anim;                    // Cowboy's animator that contains all the necessary animations

	// Particle (Dust) effects in order to strengthen the visually part of the players when they jump, dash and flip the player
	public ParticleSystem jumpDustEffect; // Jump effect
	public ParticleSystem dashDustEffect; // Dash effect
	public ParticleSystem flipDustEffect; // Flip effect

	private void Awake()
	{
		player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * playerSpeed; // X axis movement

		anim.SetFloat("Speed", Mathf.Abs(horizontalMove)); // Play the speed animation of the player

		if (Input.GetButtonDown("Jump"))
		{
			if (grounded) // Player jumps
			{
				player.AddForce(new Vector2(0f, jumpForce)); // The jump force will be on Y axis

				grounded = false;
				dash = true;

				anim.SetBool("IsJumping", true); // Play the jumping animation of the player
				anim.SetBool("DashOn", false);
				StartCoroutine(DisableJumpAnim());
				JumpDustOn();
			}

			else if (!grounded && dash == true) // The player double jumps
			{
				if (faceRightSide)
                {
					player.AddForce(new Vector2(dashForce, 0f)); // The dash force will be on X axis
					anim.SetBool("DashOn", true); // Play the dash animation of the player
					anim.SetBool("IsJumping", false);
					StartCoroutine(DisableDashAnim());
					DashDustOn();
				}

				else if (!faceRightSide)
                {
					player.AddForce(new Vector2(-dashForce, 0f)); // The dash force will be on X axis
					anim.SetBool("DashOn", true);
					anim.SetBool("IsJumping", false);
					StartCoroutine(DisableDashAnim());
					DashDustOn();
				}
				
				grounded = false;
				dash = false;
			}
		}
	}

	void FixedUpdate ()
	{
		grounded = false;

		// Player is grounded if the groundcheck position contacts anything that it is ground
		Collider2D[] colliders = Physics2D.OverlapCircleAll(jumpCheck.position, groundedRadius, ground);

		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
			}
		}

		// Moving the player
		Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

	public void Move(float move, bool jump) // Player's movement on X and Y axis
	{
		// Able to control the character when it is grounded or in air
		if (grounded || airControlling)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, player.velocity.y); // Using target velocity to move the character
			player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref velocity, smoothMovement); //  Smoothing the target velocity

			// Changing where the player looks to right
			if (move > 0 && !faceRightSide)
			{
				PlayerFlip(); // Fliping player's side to right
				FlipDustOn();
			}
			// Changing where the player looks to left
			else if (move < 0 && faceRightSide)
			{
				PlayerFlip(); // Fliping player's side to left
				FlipDustOn();
			}
		}
	}

	private void PlayerFlip() // Flip the player's side
	{
		// Switching player's side
		faceRightSide = !faceRightSide;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator DisableJumpAnim() // In order to be able to disable the jump animation as it is wanted to be only in the start of the jump
    {
		yield return new WaitForSeconds(1f);
		anim.SetBool("IsJumping", false);
	}

	IEnumerator DisableDashAnim() // In order to be able to disable the dash animation as it is wanted to be only in the start of the dash
	{
		yield return new WaitForSeconds(1f);
		anim.SetBool("DashOn", false);
	}

	void JumpDustOn() // Enabling Jump Effect
    {
		jumpDustEffect.Play();
    }

	void DashDustOn() // Enabling Dash Effect
	{
		dashDustEffect.Play();
	}

	void FlipDustOn() // Enabling Flip Effect
	{
		flipDustEffect.Play();
	}
}