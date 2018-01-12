using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {

    private GameObject buttonBase;
    private Vector3 originalPosition;
    private Vector3 limitedPosition;
    private float bounceBackSpeed;

	// Use this for initialization
	void Start () {
		buttonBase = GameObject.Find("Base");
        originalPosition = transform.position;
        limitedPosition = transform.position;
        bounceBackSpeed = 3.0f;
        Debug.Log("Original Position" + originalPosition.x.ToString() + ", " + originalPosition.y.ToString() + ", " + originalPosition.z.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Current Transform Position" + transform.position.x.ToString() + ", " + transform.position.y.ToString() + ", " + transform.position.z.ToString());
        limitedPosition = new Vector3(originalPosition.x, Mathf.Clamp(transform.position.y, -4.408f, originalPosition.y), originalPosition.z);
        transform.position = limitedPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == buttonBase)
        {
            Physics.IgnoreCollision(buttonBase.GetComponent<Collider>(), GetComponent<Collider>(), true);
        } 
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject != buttonBase)
        {
            Debug.Log("colliding with: " + collision.gameObject.name);
            Debug.Log("button pressed");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exited collision");
        transform.position = originalPosition;
    }

}
