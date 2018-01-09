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
        if (productivity.value < 25 && player.position.x != transform.position.x && player.position.z != transform.position.z)
        {
            // go towards player
            Debug.Log("gonna getcha");
            transform.position = Vector3.Lerp(originalPosition, player.position, Time.time - startTime);
        
        //if bot reaches the player, float up and down
        } else if (productivity.value < 25 && player.position == transform.position)
        {
            Debug.Log("gotcha!");
            tempPosition = transform.position;
            tempPosition.y = transform.position.y + Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
            transform.position = tempPosition;
        } else if(productivity.value >= 25 && transform.position != originalPosition)
        {
            Debug.Log("byeeee");
            transform.position = Vector3.Lerp(player.position, originalPosition, Time.time - startTime);
            // go back to original position
            //tempPosition.y = transform.position.y + Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
            //transform.position = tempPosition;
        } else
        {
            tempPosition.y = transform.position.y + Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
            transform.position = tempPosition;
        }
    }
}