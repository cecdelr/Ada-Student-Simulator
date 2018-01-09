using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour {
    public Slider productivity;

    Transform player;               // Reference to the player's position.

    public float verticalSpeed;
    public float amplitude;
	public float speed;

    private Vector3 tempPosition;
    private Vector3 originalPosition;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Use this for initialization
    void Start () {
        tempPosition = transform.position;
        originalPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (productivity.value < 25 && player.position.x != transform.position.x && player.position.z != transform.position.z)
        {
            // go towards player
			transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * speed);
        } else if(productivity.value >= 25 && transform.position.x != originalPosition.x && transform.position.z != originalPosition.z)
        {
        	// go to original position
			transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * speed);
        }
        //float up and down
        tempPosition = transform.position;
        tempPosition.y = transform.position.y + Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }
}