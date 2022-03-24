using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    float rTimer;
    int enemySpawned;
    int spawnRandomType;
    int spawnRandomLocation;
    public static int healthMod;

    public GameObject eWalker;
    public GameObject eCharger;
    public GameObject eInvisible;
    public GameObject eSingleShot;
    public GameObject eTripleShot;
    public GameObject eBoom;

    // Use this for initialization
    void Start ()
    {
        rTimer = 0;
        healthMod = 0;
        Enemy1AI.enemyDamage += 1;
        enemySpawned = 5;
        SpawnEnemy();
	}

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.gameOn)
        {
            rTimer += Time.deltaTime;

            if (rTimer >= 15f)
            {
                healthMod += 1;
                enemySpawned += 1;

                SpawnEnemy();
                rTimer = 0;
            }
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemySpawned; i++)
        {
            //randomise enemy spawn and type
            spawnRandomType = Random.Range(0, 6);
            spawnRandomLocation = Random.Range(0, 4);

            //work out results based on numbers rolled
            if (spawnRandomType == 0)
            {
                //instantiate in location
                if(spawnRandomLocation == 0)
                {
                    Instantiate(eWalker, new Vector3(17f, 0.5f, Random.Range(25, 174)), transform.rotation);
                }

                if (spawnRandomLocation == 1)
                {
                    Instantiate(eWalker, new Vector3(Random.Range(18f,158f), 0.5f,26f), transform.rotation);
                }

                if (spawnRandomLocation == 2)
                {
                    Instantiate(eWalker, new Vector3(162.5f, 0.5f, Random.Range(45f, 162f)), transform.rotation);
                }

                if (spawnRandomLocation == 3)
                {
                    Instantiate(eWalker, new Vector3(Random.Range(17f,146f), 0.5f, 175f), transform.rotation);
                }
            }

            if (spawnRandomType == 1)
            {
                if (spawnRandomLocation == 0)
                {
                    Instantiate(eCharger, new Vector3(17f, 0.5f, Random.Range(25, 174)), transform.rotation);
                }

                if (spawnRandomLocation == 1)
                {
                    Instantiate(eCharger, new Vector3(Random.Range(18f, 158f), 0.5f, 26f), transform.rotation);
                }

                if (spawnRandomLocation == 2)
                {
                    Instantiate(eCharger, new Vector3(162.5f, 0.5f, Random.Range(45f, 162f)), transform.rotation);
                }

                if (spawnRandomLocation == 3)
                {
                    Instantiate(eCharger, new Vector3(Random.Range(17f, 146f), 0.5f, 175f), transform.rotation);
                }
            }

            if (spawnRandomType == 2)
            {
                if (spawnRandomLocation == 0)
                {
                    Instantiate(eInvisible, new Vector3(17f, 0.5f, Random.Range(25, 174)), transform.rotation);
                }

                if (spawnRandomLocation == 1)
                {
                    Instantiate(eInvisible, new Vector3(Random.Range(18f, 158f), 0.5f, 26f), transform.rotation);
                }

                if (spawnRandomLocation == 2)
                {
                    Instantiate(eInvisible, new Vector3(162.5f, 0.5f, Random.Range(45f, 162f)), transform.rotation);
                }

                if (spawnRandomLocation == 3)
                {
                    Instantiate(eInvisible, new Vector3(Random.Range(17f, 146f), 0.5f, 175f), transform.rotation);
                }
            }

            if (spawnRandomType == 3)
            {
                if (spawnRandomLocation == 0)
                {
                    Instantiate(eSingleShot, new Vector3(17f, 0.5f, Random.Range(25, 174)), transform.rotation);
                }

                if (spawnRandomLocation == 1)
                {
                    Instantiate(eSingleShot, new Vector3(Random.Range(18f, 158f), 0.5f, 26f), transform.rotation);
                }

                if (spawnRandomLocation == 2)
                {
                    Instantiate(eSingleShot, new Vector3(162.5f, 0.5f, Random.Range(45f, 162f)), transform.rotation);
                }

                if (spawnRandomLocation == 3)
                {
                    Instantiate(eWalker, new Vector3(Random.Range(17f, 146f), 0.5f, 175f), transform.rotation);
                }
            }

            if (spawnRandomType == 4)
            {
                if (spawnRandomLocation == 0)
                {
                    Instantiate(eTripleShot, new Vector3(17f, 0.5f, Random.Range(25, 174)), transform.rotation);
                }

                if (spawnRandomLocation == 1)
                {
                    Instantiate(eTripleShot, new Vector3(Random.Range(18f, 158f), 0.5f, 26f), transform.rotation);
                }

                if (spawnRandomLocation == 2)
                {
                    Instantiate(eTripleShot, new Vector3(162.5f, 0.5f, Random.Range(45f, 162f)), transform.rotation);
                }

                if (spawnRandomLocation == 3)
                {
                    Instantiate(eTripleShot, new Vector3(Random.Range(17f, 146f), 0.5f, 175f), transform.rotation);
                }
            }

            if (spawnRandomType == 5)
            {
                if (spawnRandomLocation == 0)
                {
                    Instantiate(eBoom, new Vector3(17f, 0.5f, Random.Range(25, 174)), transform.rotation);
                }

                if (spawnRandomLocation == 1)
                {
                    Instantiate(eBoom, new Vector3(Random.Range(18f, 158f), 0.5f, 26f), transform.rotation);
                }

                if (spawnRandomLocation == 2)
                {
                    Instantiate(eBoom, new Vector3(162.5f, 0.5f, Random.Range(45f, 162f)), transform.rotation);
                }

                if (spawnRandomLocation == 3)
                {
                    Instantiate(eBoom, new Vector3(Random.Range(17f, 146f), 0.5f, 175f), transform.rotation);
                }
            }
        }
    }
}
