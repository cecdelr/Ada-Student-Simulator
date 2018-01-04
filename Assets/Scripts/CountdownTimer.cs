using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountdownTimer : MonoBehaviour {
	public Text text;
	public float timeRemaining;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (timeRemaining > 0){
			int minutes = (int) (timeRemaining / 60);
			int seconds = (int) (timeRemaining % 60);
			string secondsStr;
			if (seconds < 10){
				secondsStr = "0" + seconds.ToString();
			} else {
				secondsStr = seconds.ToString();
			}
			text.text = "Time Remaining: " + minutes.ToString() + ":" + secondsStr;
			timeRemaining -= Time.deltaTime;
		} else {
			text.text = "Time Up";
		}
	}
}
