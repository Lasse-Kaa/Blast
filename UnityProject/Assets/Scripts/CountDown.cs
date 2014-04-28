using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

	public float Seconds = 35;
	public float Minutes = 0;

	void Update ()
	{
		if(Seconds <= 0)
		{
			Seconds = 35;
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


