using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_1_Ghost : MonoBehaviour {

    Transform playerT;
    NavMeshAgent playerGhost;

    float distance;

	// Use this for initialization
	void Start ()
    {
        playerGhost = GetComponent<NavMeshAgent>();
        playerT = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerT.position = playerT.position;
        distance = Vector3.Distance(playerT.position, transform.position);

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
        if (other.gameObject.tag == "Player2")
        {
            Player_2_Manager.respawn2 = true;
        }
    }
}
