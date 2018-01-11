using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingObject : MonoBehaviour {

    public string favoriteObjectTag;
    private BotMovement movement;

    // Use this for initialization
    void Start () {
        movement = GetComponent<BotMovement>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == favoriteObjectTag)
        {
            Destroy(collision.gameObject);
            // 
        } else
        {
            Debug.Log("Chris-Bot is sad you would throw things at him.");
        }
    }
}
