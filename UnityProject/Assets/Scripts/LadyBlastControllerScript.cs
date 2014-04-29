using UnityEngine;
using System.Collections;

public class LadyBlastControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	// Ground state: Will check whether or not the PC is standing on an object
	// and control the fall animation
	bool onGround = false;
	public Transform groundCheck;
	float groundRadius = 0.22f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public int timer = 300000;
	public int coinCounter;
	// Reference to animator
	Animator anim;

	// useless line of cmment

	// Use this for initialization
	void Start () {
		//set coincounter to 0 in the beginning
		coinCounter = 0;

		GameObject.Find ("dieScreen").renderer.enabled = false;

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

		//if (transform.position.y < -10) {
		//	Application.LoadLevel(Application.loadedLevel);		
		//}

		if (transform.position.y < -10) {
			//GameObject.Find ("dieScreen").renderer.enabled = true;
			Restart();
		}

		if (Input.GetKeyDown("q") && GameObject.Find ("dieScreen").renderer.enabled == true)
		{	
			GameObject.Find ("dieScreen").renderer.enabled = false;
			Application.LoadLevel ("Scene");
			Debug.Log ("Died");
		}

	}

	// The jump input is listened for inside Update instead of 
	// Fixed Update to make it more accurate. Otherwise the input might be missed
	void Update(){
		if(onGround && Input.GetButtonDown("Jump")){
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}

	//the OnGUI function generates a text label on the screen with a rectangular shape. The content of
	//the label is "score" and gets the count update from the coinCounter variable.
	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 150, 100), "Score: " + coinCounter);
	}


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
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public void Restart(){
		//Time.timeScale = 0;
		// A BETTER WAY TO DO ALL THIS, IS TO USE A NEW SCENE TO SHOW THAT YOU DIED!
		maxSpeed = 0;
		jumpForce = 0;
		transform.position = new Vector3 (0, 0, 0);
		GameObject.Find ("dieScreen").renderer.enabled = true;
	}
}