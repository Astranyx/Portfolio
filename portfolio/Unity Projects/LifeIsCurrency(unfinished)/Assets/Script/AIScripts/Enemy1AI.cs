using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1AI : MonoBehaviour
{

    Animator animator;
    float distance;
    public Transform PlayerPos;
    NavMeshAgent Enemy1;
    GameObject rManager;

    float duration;


    int Spawnstate;
    int Spawntype;
    int enemyHealth;
    bool canAttack;
    public static int enemyDamage;
    // Use this for initialization
    void Start()
    {
        enemyDamage = 1;
        enemyHealth = 1;
        canAttack = true;
        Enemy1 = GetComponent<NavMeshAgent>();



        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        enemyHealth += RoundManager.healthMod;

        // Rolls a 100 side dice and provides a number, this will be used to spawn the enemy as an "Elite"
        Spawnstate = Random.Range(1, 101);
        if (Spawnstate <= 10)
        {
            Spawntype = Random.Range(1, 4);
            transform.localScale *= 2.5f;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHealth <= 0)
        {
            if (Spawntype >= 1)
            {
                PlayerStats.soulCount += 5 + PlayerStats.soulMod;
            }
            else
            {
                PlayerStats.soulCount += 1 + PlayerStats.soulMod;
            }
           
            Destroy(this.gameObject);
        }

        if (gameObject.tag == "Enemy")
        {
            PlayerPos.position = PlayerPos.position;
            distance = Vector3.Distance(PlayerPos.position, transform.position);

            if (distance >= 3.1f)
            {
                Enemy1.SetDestination(PlayerPos.position);
                animator.Play("Walk");
            }

            if (distance < 3f && canAttack && gameObject.tag == "Enemy")
            {
                StartCoroutine("AttackRoutine");
                Soundsystem.attack = true;
            }
        }
        else if (gameObject.tag == "Freeze")
        {
            Enemy1.SetDestination(PlayerPos.position);
            StartCoroutine("Stun");
        }
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
        }
    }

    IEnumerator AttackRoutine()
    {
        canAttack = false;
       
        animator.Play("Attack");

        if (Spawntype == 1)
        {
            var Dot = gameObject.AddComponent<Firedot>();
            Dot.Damage = 10f;
            Dot.ApplyEveryNSeconds = 1f;
            Dot.Delay = 3f;
            Dot.ApplyDamageNTimes = 5f;
            Dot.Seconds = 10f;

        }
        else if (Spawntype == 2)
        {
            var Dot = gameObject.AddComponent<Weakness>();
            Dot.Damage = 0f;
            Dot.ApplyEveryNSeconds = 10f;
            Dot.Delay = 3f;
            Dot.Seconds = 10f;
            Dot.ApplyDamageNTimes = 1f;
        }
        else if (Spawntype == 3)
        {
            var Dot = gameObject.AddComponent<Petrified>();
            Dot.Damage = 0f;
            Dot.ApplyEveryNSeconds = 5f;
            Dot.Delay = 1f;
            Dot.Seconds = 5f;
            Dot.ApplyDamageNTimes = 1f;
        }

        PlayerStats.soulCount -= enemyDamage;

        yield return new WaitForSeconds(1.5f);
        canAttack = true;
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(5f);
        gameObject.tag = "Enemy";
    }
}
