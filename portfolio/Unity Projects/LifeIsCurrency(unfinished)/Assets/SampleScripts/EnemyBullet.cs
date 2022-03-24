using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject player;
    Vector2 direction;
    Rigidbody2D rBody;
    float Speed = 5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

        rBody = GetComponent<Rigidbody2D>();
        direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
        rBody.velocity = direction * Speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // speeding up the bullet to it's wanted speed
        rBody.velocity = rBody.velocity.normalized * Speed;
    }
}
