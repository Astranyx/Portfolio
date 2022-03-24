using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour {

    Rigidbody rBody;
    float speed = 10f;
   

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.velocity = transform.forward * speed * Time.deltaTime;     
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
