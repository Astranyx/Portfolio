using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_2_Ghost : MonoBehaviour {

    //transform for player position
    Transform playerT;

    //navmesh for AI
    NavMeshAgent playerGhost;

    float distance;

    // Use this for initialization
    void Start()
    {
        //assign navmesh and transform
        playerGhost = GetComponent<NavMeshAgent>();
        playerT = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //update player position every frame and calculate distance between player/ghost
        playerT.position = playerT.position;
        distance = Vector3.Distance(playerT.position, transform.position);

        //move if too far, stop if too close
        if (distance > 3f)
        {
            playerGhost.SetDestination(playerT.position);
        }
        else
        {
            playerGhost.SetDestination(transform.position);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player1")
        {
            
        }
    }
}
