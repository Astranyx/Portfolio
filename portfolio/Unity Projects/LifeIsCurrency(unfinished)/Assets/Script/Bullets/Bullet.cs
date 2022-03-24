using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    GameObject player;
    Vector3 Dir;
    Rigidbody rBody;
    float speed = 10f;
    
    // Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 PlayerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        rBody = GetComponent<Rigidbody>();
        Dir = new Vector3(PlayerPos.x - transform.position.x, PlayerPos.y - transform.position.y, PlayerPos.z - transform.position.z);
        rBody.velocity = Dir * speed * Time.deltaTime;
	}

    void FixedUpdate()
    {
        // speeding up the bullet to it's wanted speed
        rBody.velocity = rBody.velocity.normalized * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.soulCount -= Enemy1AI.enemyDamage;           
        }
    }
}
