using UnityEngine;
using System.Collections;

public class LadyBlastControllerScript : MonoBehaviour {
	
	public float maxSpeed = 10f;
	bool facingRight = true;
	
	// Ground state: Will check whether or not the PC is standing on an object
	// and control the fall animation
	bool onGround = true;
	public Transform groundCheck;
	float groundRadius = 0.5f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public int timer = 300000;
	public int coinCounter;
	
	// Reference to animator
	Animator anim;
	
	private float prevPosY; 	 	
	
	// Use this for initialization
	void Start () {
		// Set coincounter to 0 in the beginning
		coinCounter = 0;
		
		GameObject.Find("dieScreen").renderer.enabled = false;
		
		// Gets component from animator
		anim = GetComponent<Animator>();
	} 
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// This line is used with transitions in the Mecanim to make a jump animation
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		// Gets player left and right input
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
		
		// When player falls below a certain y position, call the Restart method
		if (transform.position.y < -10) {
			Restart();
		}
		
	}
	
	// The jump input is listened for inside Update instead of 
	// Fixed Update to make it more accurate. Otherwise the input might be missed
	void Update(){
		
		// This is the jump code. Checks if previous y position was close to current y position. If not, player can jump
		if(transform.position.y > prevPosY-0.01f && transform.position.y < prevPosY+0.01f && Input.GetButtonDown("Jump")){
			print ("hej");
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
		
		// Stores y position for use in next frame
		prevPosY = transform.position.y;
		
		// Load Main Menu on any key input
		if (Input.anyKeyDown && GameObject.Find ("dieScreen").renderer.enabled == true)
		{	
			Application.LoadLevel ("Main Menu");
		}
	}
	
	// The OnGUI function generates a text label on the screen with a rectangular shape. The content of
	// the label is "score" and gets the count update from the coinCounter variable.
	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 150, 100), "Score: " + coinCounter);
	}
	
	// Method to pickup coin, destroy it and add points to score
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "coin")
		{
			coinCounter += 15;
			Destroy(other.gameObject);
			Debug.Log("You have gained ");
		}
		
	}
	
	// Flip takes the world and flips the world 
	// and the animation to save animation
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	public void Restart()
	{
		// When the restart function/the diescreen occurs the movement of the player is set to 0.
		// This is done to prevent the user from moving the player after the gameover screen has popped up.
		maxSpeed = 0;
		jumpForce = 0;
		transform.position = new Vector3 (0, 0, 0);
		GameObject.Find ("dieScreen").renderer.enabled = true;
	}
}