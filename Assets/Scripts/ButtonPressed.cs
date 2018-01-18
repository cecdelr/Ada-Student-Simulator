using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour {

    public Slider productivity;
    public Text screenText;
    private GameObject buttonBase;
    private Vector3 originalPosition;
    private Vector3 limitedPositionAtRange;
    private float bounceBackSpeed;
    private Dictionary<string, Dictionary<string, string>> buttonAndEventsList;
    //         {
    //              "buttonName": "buttonNameHere"
    //              "screenText": "texttexttext",
    //              "isPressed": "true" <--- YOOooo, this is a string NOT a bool   
    //         }


    // Use this for initialization
    void Start () {
		buttonBase = GameObject.Find("Base");
        originalPosition = transform.position;
        limitedPositionAtRange = transform.position;
        bounceBackSpeed = 3.0f;
        buttonAndEventsList = new Dictionary<string, Dictionary<string, string>>(){
            { "WriteTestButton", new Dictionary<string, string>(){
                        { "screenText", "red"},
                        { "isPressed", "false"},
                        { "productivityValue", "5"},
                        { "lastButtonToPush", "RefactorCodeButton"}

            } },
            { "WriteCodeButton", new Dictionary<string, string>(){
                        { "screenText", "green"},
                        { "isPressed", "false"},
                        { "productivityValue", "5"},
                        { "lastButtonToPush", "WriteTestButton"}
            } },
            { "RefactorCodeButton", new Dictionary<string, string>(){
                        { "screenText", "refactor"},
                        { "isPressed", "false"},
                        { "productivityValue", "10"},
                        { "lastButtonToPush", "WriteCodeButton"}
            } }
        };

        //Debug.Log("Original Position" + originalPosition.x.ToString() + ", " + originalPosition.y.ToString() + ", " + originalPosition.z.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        // the button can only go up and down the y axis at a certain range
        // -4.408f is slightly above where the base's bottom would be
        limitedPositionAtRange = new Vector3(originalPosition.x, Mathf.Clamp(transform.position.y, -4.408f, originalPosition.y), originalPosition.z);
        transform.position = limitedPositionAtRange;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ignore base's collisions because the base also has a rigidbody
        if (collision.gameObject == buttonBase)
        {
            Physics.IgnoreCollision(buttonBase.GetComponent<Collider>(), GetComponent<Collider>(), true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // if the other object in contact with the button is a trigger AND the position of the object is above the button
        if (other.isTrigger && 
            other.gameObject.transform.position.y > transform.position.y) {
            //Debug.Log(name);
            Debug.Log("being pressed: " + name + "on trigger enter function nao. collided with " + other.gameObject.name);
            screenText.text = buttonAndEventsList[name]["screenText"];
            if (buttonAndEventsList[name]["isPressed"] == "false")
            {
                buttonAndEventsList[name]["isPressed"] = "true";
                int prodNum = System.Int32.Parse(buttonAndEventsList[name]["productivityValue"]);
                productivity.value += prodNum;
            }
            productivity.value += 5;
            ProductivityScript.productiveAction = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject != buttonBase)
        {
            transform.position = originalPosition;
        }
    }
}
