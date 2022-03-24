using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SplitEnemy : MonoBehaviour {

    public GameObject EnemyBullet;
    Transform PlayerPos;
    NavMeshAgent Enemy2;
    float distance;
    float DistanceToStop;
    bool canshot;
    public float ObstacleRange = 5f;
    Vector3 rotateAddition;
    GameObject rManager;
    int Spawnstate;
    int enemyHealth;
    bool canAttack;
    public static int enemyDamage;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        Enemy2 = GetComponent<NavMeshAgent>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        canshot = true;
        enemyDamage = 1;
        enemyHealth = 1;
        enemyHealth += RoundManager.healthMod;
        DistanceToStop = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos.position = PlayerPos.position;
        distance = Vector3.Distance(PlayerPos.position, transform.position);

        if (enemyHealth <= 0)
        {
            PlayerStats.soulCount += 4 + PlayerStats.soulMod;
            Destroy(this.gameObject);
        }

        if (gameObject.tag == "Enemy")
        {
            if (distance > DistanceToStop)
            {
                Enemy2.SetDestination(PlayerPos.position);
                anim.Play("Walk");
            }
            else if (distance <= DistanceToStop)
            {
                Enemy2.SetDestination(transform.position);
                if (canshot)
                {
                    StartCoroutine("FireBullet");
                    Soundsystem.Fireball = true;
                    canshot = false;
                }
            }
        }
        else if (gameObject.tag == "Freeze")
        {
            Enemy2.SetDestination(transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Damage")
        {
            enemyHealth -= PlayerStats.meleeDamage;
        }

        if(other.gameObject.tag == "ProjDamage")
        {
            enemyHealth -= PlayerStats.rangedDamage;
        }

        if(other.gameObject.tag == "Nuke")
        {
            enemyHealth -= CameraController.nukeDamage;
        }

        if (other.gameObject.tag == "Frozen")
        {
            gameObject.tag = "Freeze";
            StartCoroutine("Stun");
        }
    }

    IEnumerator FireBullet()
    {
        //spawns the bullets on the enemy, bullet 2/3 are spawning inside the first bullet

        yield return new WaitForSeconds(0.5f);
        anim.Play("Attack");
        transform.LookAt(PlayerPos);
        Instantiate(EnemyBullet, transform.position, transform.rotation);
        Instantiate(EnemyBullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 20,0)));
        Instantiate(EnemyBullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0,-20,0)));        
        yield return new WaitForSeconds(3f);
        canshot = true;
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(5f);
        gameObject.tag = "Enemy";
    }
}
