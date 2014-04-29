using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//Gui is needed when creating the menu for the graphics.
	void OnGUI ()
	{
		// All the code below contains the game title Blast, Play Button and Quit Button. 
		//Furthermore the cordinates for their location on screen 
		GUI.Label (new Rect (Screen.width/2, 10, 100, 100), "Blast");
		if (GUI.Button(new Rect(10,200,100,100), "Play"))
	{
			//When pressing the play button it switches to the level.
			Application.LoadLevel (0);	
		}

		if (GUI.Button(new Rect(10,300,100,100), "Quit"))
		{
			//Quit function
			Application.Quit ();
	}
}
}

