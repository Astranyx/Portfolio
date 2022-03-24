using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2AI : MonoBehaviour {

    public GameObject EnemyBullet;
    public Transform PlayerPos;
    NavMeshAgent Enemy2;
    float distance;
    float DistanceToStop;
    bool canshot;
    bool canAttack;
    public float ObstacleRange = 5f;
    GameObject rManager;
    int Spawnstate;
    int enemyHealth;
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
        DistanceToStop = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            PlayerStats.soulCount += 3 + PlayerStats.soulMod;
            Destroy(this.gameObject);
        }

        if (gameObject.tag == "Enemy")
        {
            PlayerPos.position = PlayerPos.position;
            distance = Vector3.Distance(PlayerPos.position, transform.position);

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

    IEnumerator FireBullet()
    {
        anim.Play("Attack");
        yield return new WaitForSeconds(0.5f);
        Instantiate(EnemyBullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(3f);
        canshot = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damage")
        {
            enemyHealth -= PlayerStats.meleeDamage;
        }

        if (other.gameObject.tag == "ProjDamage")
        {
            enemyHealth -= PlayerStats.rangedDamage;
        }

        if (other.gameObject.tag == "Nuke")
        {
            enemyHealth -= CameraController.nukeDamage;
        }

        if (other.gameObject.tag == "Frozen")
        {
            gameObject.tag = "Freeze";
            StartCoroutine("Stun");
        }
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(5f);
        gameObject.tag = "Enemy";
    }
}




