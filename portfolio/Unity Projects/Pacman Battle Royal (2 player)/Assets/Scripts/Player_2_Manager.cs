using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Manager : MonoBehaviour {

    //public static to make it accessible to all other scripts


    //score modifier
    

    public Transform p2Spawn, p2Ghost, player2Object, player2Ghost;
    public GameObject orbObj;
    GameObject[] orbPosition;

    public static bool respawn2;

    private void Start()
    {
        respawn2 = false;
        orbPosition = GameObject.FindGameObjectsWithTag("OrbPosition");
    }


    private void Update()
    {
        if (respawn2)
        {
            respawnPlayer2();
            respawn2 = false;
        }

        if (Player_2_Move.player2Deposit)
        {
            OrbReset();
            Player_2_Move.player2Deposit = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if player hands in orbs multiply by modifier and add it to total, reset carried orbs and modifier
        
    }

    void respawnPlayer2()
    {
        player2Object.position = p2Spawn.position;
        player2Ghost.position = p2Ghost.position;
        Player_2_Move.player2Carry = 0;
        OrbReset();
    }

    void OrbReset()
    {
        for (int i = 0; i < orbPosition.Length; i++)
        {
            if (orbPosition[i].transform.childCount == 0)
            {
                Instantiate(orbObj, orbPosition[i].transform);
            }
        }
    }
}
