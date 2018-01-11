using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private GameObject collidingObject;
    private GameObject objectInHand;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
	

	void Update () {
        //grab object
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject && collidingObject.tag != "Button")
            {
                GrabObject();
            }
        }

        // release object
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        
        Debug.Log(col.gameObject.tag);
        // if it's not a button
        if (col.gameObject.tag != "Button")
        {
            // ignore collision
            Physics.IgnoreCollision(col.collider, GetComponents<Collider>()[1]);
        }

    }

    private void SetCollidingObject(Collider col)
    {
        // if already holding something or object doesn't have a rigidbody, can't grab it
        if(collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // when object exits the trigger = "letting go", no colliding objects
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        // colliding object (object you CAN hold) is now object in hand (object you ARE holding)
        objectInHand = collidingObject;
        collidingObject = null;
        // FixedJoint is a way to attach two objects with a RigidBody together
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

 
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // if a fixedjoint exists...
        if (GetComponent<FixedJoint>())
        {
            // destroy fixedjoint connection
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // "throw" the object from your hand
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // nothing's on your hand anymore :(
        objectInHand = null;
    }
}
