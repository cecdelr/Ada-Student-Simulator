using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour {
    public Slider productivity;

    Transform player;               // Reference to the player's position.
    NavMeshAgent nav;               // Reference to the nav mesh agent.

    public float verticalSpeed;
    public float amplitude;
	public float speed = 0.001f;

    private Vector3 tempPosition;
    private Vector3 originalPosition;

    private float startTime;
    private float journeyLength;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }
    // Use this for initialization
    void Start () {
        tempPosition = transform.position;
        originalPosition = transform.position;

        startTime = Time.time;
        journeyLength = Vector3.Distance(originalPosition, player.position);

    }

    // Update is called once per frame
    void Update()
    {
		float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        if (productivity.value < 25 && player.position.x != transform.position.x && player.position.z != transform.position.z)
        {
            // go towards player
            Debug.Log("gonna getcha");
			transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * 1.0F);
        
        //if bot reaches the player, float up and down
        } else if(productivity.value >= 25 && transform.position.x != originalPosition.x && transform.position.z != originalPosition.z)
        {
            Debug.Log("byeeee");
			transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * 1.0F);
        } else
        {
        	Debug.Log("in position");
        	tempPosition = transform.position;
            tempPosition.y = transform.position.y + Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
            transform.position = tempPosition;
        }
    }
}