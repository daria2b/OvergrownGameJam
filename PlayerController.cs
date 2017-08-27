using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 12f;
	public float jumpForce = 1000f;

	//references to various components
	Rigidbody2D myRB;
	Animator myAnim;

	//boolean to control which way the character is facing and whether it stands on ground
	bool facingRight;
	bool onGround;

	// Use this for initialization
	void Start () {
		facingRight = true;
		//get info on components attached to player and store them in variables
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		onGround = false;
	}

	//set character onGround variable to true if player touches ground
	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.tag == "Ground")
			onGround = true;
			myAnim.SetBool ("inAir", false);
	}

	void Update () {
		//enable player jumping
		if ((Input.GetAxis ("Jump") > 0 || Input.GetKeyDown (KeyCode.W))&& onGround) {
			myRB.AddForce (new Vector2 (0, jumpForce));
			myAnim.SetBool ("inAir", true);
			onGround = false;
		}
	}

	void FixedUpdate () {
		//get input from player and perform actions where needed
		float move = Input.GetAxis ("Horizontal");

		//if movement speed is not zero, communicate it to the animator to change the animation
		myAnim.SetFloat("speed", Mathf.Abs (move));

		//move the player by using velocity
		myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);

		//flip the character if it faces the wrong direction
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
