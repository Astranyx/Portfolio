using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Move : MonoBehaviour {

    //bool for forced movements
    bool moveLeft;
    bool moveRight;
    bool moveUp;
    bool moveDown;

    public static int player2Carry;
    public static int player2Total;
    public static bool player2Pick;
    public static bool player2Deposit;

    int modifier;

    //speedy speed float
    public float speed;

    // Use this for initialization
    void Start()
    {
        player2Deposit = false;

        speed = 5 * Time.deltaTime;
        moveUp = false;
        moveLeft = false;
        moveRight = false;
        moveDown = false;

        modifier = 1;
        player2Carry = 0;
        player2Pick = false;
    }

    // Update is called once per frame
    void Update()
    {
        //manipulate boolean values so that player moves on coorect trajectory
        if (Input.GetKeyDown(KeyCode.I))
        {
            moveUp = true;
            moveLeft = false;
            moveRight = false;
            moveDown = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            moveUp = false;
            moveLeft = false;
            moveRight = false;
            moveDown = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            moveUp = false;
            moveLeft = true;
            moveRight = false;
            moveDown = false;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            moveUp = false;
            moveLeft = false;
            moveRight = true;
            moveDown = false;
        }

        if (RoundManager.gameON) { 
        //movement
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

        if (player2Pick)
        {
            //if the player picks up an orb and the new score is divisible by 20, modifier goes up by 1
            if (player2Carry % 20 == 0)
            {
                modifier += 1;
            }
            Debug.Log(modifier);
            player2Pick = false;
        }
    }

    //orb pickup for player 2
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "orb")
        {
            //bool to make sure it's only picked up once
            player2Pick = true;
            
            //increase score
            player2Carry += 1;

            //get rid of orb
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player2Drop")
        {
            player2Deposit = true;
            player2Total += player2Carry * modifier;
            player2Carry = 0;
            modifier = 1;
        }
    }
}
