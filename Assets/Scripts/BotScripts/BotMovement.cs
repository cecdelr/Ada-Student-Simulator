using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour {
    public Slider productivity;
    public int targetReference; // index in target array
    public float targetProductivityLevel;

    GameObject player;               // Reference to the player's position.

    public float verticalSpeed;
    public float amplitude;
    public float speed;

    private Vector3 tempPosition;
    private Vector3 originalPosition;
    private CapsuleCollider target;
    private Vector3 targetPosition;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("LocationTarget");
        Debug.Log("Number of Capsule Colliders:" + player.GetComponents<CapsuleCollider>().Length.ToString());
        target = player.GetComponents<CapsuleCollider>()[targetReference];
        targetPosition = target.transform.position + target.center;
        Debug.Log("Target Reference: " + targetReference.ToString());
        Debug.Log("Capsule Collider Position: " + targetPosition.x.ToString() + ", " + targetPosition.y.ToString() + ", " + targetPosition.z.ToString());

    }
    // Use this for initialization
    void Start() {
        tempPosition = transform.position;
        originalPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (productivity.value < targetProductivityLevel && targetPosition.x != transform.position.x && targetPosition.z != transform.position.z)
        {
            moveToTarget();
        } else if (productivity.value >= targetProductivityLevel && transform.position.x != originalPosition.x && transform.position.z != originalPosition.z)
        {
            moveToOriginalPosition();
        }
        floatToPosition();
    }

    private void moveToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }

    private void moveToOriginalPosition()
    {
        transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * speed);
    }

    private void floatToPosition (){
        //float up and down
        tempPosition = transform.position;
        tempPosition.y = transform.position.y + Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }
}