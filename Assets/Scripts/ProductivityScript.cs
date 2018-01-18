using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductivityScript : MonoBehaviour {

    public Text timer;

    private Slider productivity;
    private float lastCheckTime = 0;
    private float gapTime = 3.0f;
    private float currentProductivityValue;
    public static bool productiveAction;

	// Use this for initialization
	void Start () {
        productivity = GetComponent<Slider>();
        // start the game off with 50 productivity points
        productivity.value = 50;
        currentProductivityValue = productivity.value;
        productiveAction = false;
	}
	
	// Update is called once per frame
	void Update () {
        float currentProductivity = productivity.value;

        //Debug.Log("Time.time = " + Time.time.ToString() + " | lastCheckTime: " + lastCheckTime.ToString() + " | currentProductivityValue: " + currentProductivityValue.ToString());

        // while there's time left
        if (timer.GetComponent<CountdownTimer>().timeRemaining > 0) {

            // if it hasn't changed in gapTime seconds
            if (((Time.time - lastCheckTime) > gapTime) && !productiveAction)
            {
                Debug.Log("Player hasn't been productive in " + lastCheckTime.ToString() + " seconds");
                // decrease productivity per second, start immediately
                InvokeRepeating("decreaseProductivity", 5.0f, 5.0f);
                
            }
            else if(productiveAction)// else if it did change positively
            {
                productiveAction = false;
                Debug.Log("**********Did something productive!*********");
                CancelInvoke();
                lastCheckTime = Time.time;
            }

        } else
        {
            Invoke("endGame", 0);
        }

    }

    private void decreaseProductivity() {
        currentProductivityValue = productivity.value;
        productivity.value -= 0.01f;
    }

    private void endGame() {
        
        ControllerGrabObject[] controllerScripts = GetComponents<ControllerGrabObject>();
        foreach (ControllerGrabObject script in controllerScripts)
        {
            script.enabled = false;
        }
        CancelInvoke();
        Debug.Log("Time's Up");
        //timer's run out
    }

}
