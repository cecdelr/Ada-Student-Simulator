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


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        productivityScore = productivity.value;
        nav = GetComponent<NavMeshAgent>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (productivityScore < 25)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}
