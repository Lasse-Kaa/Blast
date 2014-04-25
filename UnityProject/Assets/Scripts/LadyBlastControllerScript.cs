using UnityEngine;
using System.Collections;

public class LadyBlastControllerScript : MonoBehaviour {
	
	public float maxSpeed = 10f;
	bool facingRight = true;

	// Ground state: Will check whether or not the PC is standing on an object
	// and control the fall animation
	bool onGround = false;
	public Transform groundCheck;
	float groundRadius = 2.0f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	// Reference to animator
	Animator anim;
	
	// Use this for initialization
	void Start () {

		// Gets component from animator
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Will check whether or not the PC is touching anything. 
		// If result is true, PC is on the ground
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", onGround);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis ("Horizontal");

		// Sets parameter Speed to absolute value move
		anim.SetFloat ("Speed", Mathf.Abs (move));
		
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		
		// If the player is moving to the left and facing right, call Flip
		if(move < 0 &&!facingRight)
			Flip ();
		// If the player is moving to the right and facing left, call Flip
		else if(move > 0 && facingRight)
			Flip ();
	}

	// The jump input is listened for inside Update instead of 
	// Fixed Update to make it more accurate. Otherwise the input might be missed
	void Update(){
		if(onGround && Input.GetButtonDown("Jump")){
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}

	// Flip takes the world and flips the world 
	// and the animation to save animation
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
