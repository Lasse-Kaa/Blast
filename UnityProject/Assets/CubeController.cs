using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxis ("Horizontal") * transform.right * Time.deltaTime);  
	}
}
