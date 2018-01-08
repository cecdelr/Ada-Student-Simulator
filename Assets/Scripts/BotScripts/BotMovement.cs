using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour {
    public Slider productivity;

    Transform player;               // Reference to the player's position.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    float productivityScore;

    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;

    private Vector3 tempPosition;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }
    // Use this for initialization
    void Start () {
        tempPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //if (productivity.value < 25)
        //{
            // ... set the destination of the nav mesh agent to the player.
            //nav.SetDestination(player.position);
        //}
        // Otherwise...
        //else
        //{
            // ... disable the nav mesh agent.
            //nav.enabled = false;
        //}
    }

    void FixedUpdate()
    {
        tempPosition.x = transform.position.x + horizontalSpeed;
        tempPosition.y = transform.position.y + Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }
}