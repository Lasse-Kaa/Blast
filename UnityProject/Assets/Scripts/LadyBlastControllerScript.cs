using UnityEngine;
using System.Collections;

public class LadyBlastControllerScript : MonoBehaviour {
	
	public float maxSpeed = 10f;
	bool facingRight = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		
		// If the player is moving to the left and facing right, call Flip
		if(move < 0 &&!facingRight)
			Flip ();
		// If the player is moving to the right and facing left, call Flip
		else if(move > 0 && facingRight)
			Flip ();
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
