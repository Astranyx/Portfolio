using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Manager : MonoBehaviour {

    //public static to make it accessible to all other scripts



    public Transform p1Spawn, p1Ghost, player1Object, player1Ghost;
    public GameObject orbObj;
    GameObject[] orbPosition;

    public static bool respawn1;

    private void Start()
    {     
        respawn1 = false;
        orbPosition = GameObject.FindGameObjectsWithTag("OrbPosition");
    }

    private void Update()
    {        
        if (respawn1)
        {
            respawnPlayer1();
            respawn1 = false;
        }

        if (Player_1_Move.player1Deposit)
        {
            OrbReset();
            Player_1_Move.player1Deposit = false;
        }
    }

    void respawnPlayer1()
    {
        player1Object.position = p1Spawn.position;
        player1Ghost.position = p1Ghost.position;
        Player_1_Move.player1Carry = 0;
        OrbReset();
    }

    void OrbReset()
    {
        for (int i = 0; i < orbPosition.Length; i++)
        {
            if(orbPosition[i].transform.childCount == 0)
            {
                Instantiate(orbObj, orbPosition[i].transform);
            }
        }
    }
}
