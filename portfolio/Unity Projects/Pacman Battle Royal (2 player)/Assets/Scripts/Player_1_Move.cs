using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Move : MonoBehaviour {

    bool moveLeft;
    bool moveRight;
    bool moveUp;
    bool moveDown;

    public static bool player1Pick;
    public static bool player1Deposit;

    //score modifier
    int modifier;

    public static int player1Carry;
    public static int player1Total;

    public float speed;

    // Use this for initialization
    void Start()
    {
        player1Pick = false;
        player1Deposit = false;

        speed = 5 * Time.deltaTime;
        moveUp = false;
        moveLeft = false;
        moveRight = false;
        moveDown = false;

        modifier = 1;

        player1Carry = 0;
        player1Total = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveUp = true;
            moveLeft = false;
            moveRight = false;
            moveDown = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveUp = false;
            moveLeft = false;
            moveRight = false;
            moveDown = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveUp = false;
            moveLeft = true;
            moveRight = false;
            moveDown = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveUp = false;
            moveLeft = false;
            moveRight = true;
            moveDown = false;
        }

        if (RoundManager.gameON)
        {

            if (moveRight)
            {
                transform.position += new Vector3(1, 0, 0) * speed;
            }

            if (moveLeft)
            {
                transform.position += new Vector3(-1, 0, 0) * speed;
            }

            if (moveUp)
            {
                transform.position += new Vector3(0, 0, 1) * speed;
            }

            if (moveDown)
            {
                transform.position += new Vector3(0, 0, -1) * speed;
            }
        }

        if (player1Pick)
        {
            //if the player picks up an orb and the new score is divisible by 20, modifier goes up by 1
            if (player1Carry % 20 == 0)
            {
                modifier += 1;
            }
            player1Pick = false;
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "orb")
        {
            player1Pick = true;
            player1Carry += 1;
            Destroy(other.gameObject);
        }

        //if player hands in orbs multiply by modifier and add it to total, reset carried orbs and modifier
        if (other.gameObject.tag == "Player1Drop")
        {
            player1Deposit = true;
            player1Total += player1Carry * modifier;
            player1Carry = 0;
            modifier = 1;
        }
    }
}
