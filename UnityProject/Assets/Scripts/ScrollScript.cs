using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {

	public float speed = 0f;
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTextureOffset = new Vector2((Time.time * speed)%1,1.0f);
	}
}
