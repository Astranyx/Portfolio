using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour {

    GameObject Player;
	
    // Use this for initialization
	void Start () {
    Player = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {
		
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent = Player.transform;
            tag = "Player";
            GetComponent<MeshCollider>().isTrigger = false;
        }
    }
}
