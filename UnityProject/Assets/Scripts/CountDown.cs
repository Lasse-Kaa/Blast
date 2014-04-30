using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

	public float Seconds = 35;
	public float Minutes = 0;
	private bool alive = true;

	public LadyBlastControllerScript lbcScript;

	void Start()
	{
		// Retrieves the script LadyBlastControllerscript
		lbcScript = GetComponent<LadyBlastControllerScript> ();
		//sets initial time to 30 seconds. 
		Seconds = 30;
		}

	void die()
	{
		print ("You blow! (cock)");
		// Put in image here
		lbcScript.Restart ();
		}

	void Update ()
	{
		//if the time runs out and the player is still alive, the player will die. 
		if(Seconds <= 0 && alive)
		{
			alive = false;
			die ();

			// Put in the image

			if(Minutes > 1)
			{
				Minutes --;
			}

			else
			{
				Minutes = 0;
				Seconds = 0;

				//To.String formats the time so there is no decimal numbers
				GameObject.Find("TimerText").guiText.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
			}
		}
		else
		{
			//The time in seconds it takes to complete the last frame
			Seconds -= Time.deltaTime;
		}

		// These lines ensures the time is shown as X:XX and not X:XX:XXXXX
		if(Mathf.Round(Seconds) <= 9)
		
		{
			GameObject.Find("TimerText").guiText.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
		}

		else
		{
			GameObject.Find("TimerText").guiText.text = Minutes.ToString("f0") + ":" + Seconds.ToString("f0");
		}

	}
}


