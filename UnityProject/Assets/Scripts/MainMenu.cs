using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI ()
	{
		GUI.Label (new Rect (Screen.width/2, 10, 100, 100), "Blast");
		if (GUI.Button(new Rect(10,200,100,100), "Play"))
	{
			Application.LoadLevel (0);	
		}

		if (GUI.Button(new Rect(10,300,100,100), "Quit"))
		{
			Application.Quit ();
	}
}
}

