using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampTextToWhiteboard : MonoBehaviour {

	public Text whiteboardText;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 textPos = Camera.main.WorldToScreenPoint(this.transform.position);
		whiteboardText.transform.position = textPos;
	}
}
