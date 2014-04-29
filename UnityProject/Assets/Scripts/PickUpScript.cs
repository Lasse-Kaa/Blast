using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

	private int coinCounter = 0;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player")
		{
			coinCounter = coinCounter + 15;
			Destroy(this.gameObject);
			Debug.Log("You have gained X amount of golds!");
		}

	}


}



