using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoom : MonoBehaviour
{

    public Transform PlayerPos;
    NavMeshAgent EnemyInvis;
    float distance;
    public float BoomDistance;
    int Spawnstate;
    int Spawntype;

    int enemyHealth;

    Animator anim;
    // Use this for initialization
    void Start()
    {

        enemyHealth = 1 + RoundManager.healthMod;
        EnemyInvis = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    
        // Rolls a 100 side dice and provides a number, this will be used to spawn the enemy as an "Elite"
        Spawnstate = Random.Range(1, 101);
        if (Spawnstate < 10)
        {
            Spawntype = Random.Range(1, 4);
            transform.localScale *= 2.5f;
        }
    
   
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(PlayerPos.position, transform.position);

        if (enemyHealth <= 0)
        {
            if (Spawntype >= 1)
            {
                PlayerStats.soulCount += 5 + PlayerStats.soulMod;
            }
            else 
            {
                PlayerStats.soulCount += 2 + PlayerStats.soulMod;
            }
            
            Destroy(gameObject);
        }

        if (distance <= BoomDistance)
        {
            PlayerStats.soulCount -= Enemy1AI.enemyDamage * 2;

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
                Dot.ApplyEveryNSeconds = 1f;
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

            
            Soundsystem.boom = true;
            Destroy(this.gameObject);
        }
        else
        {
            if (gameObject.tag == "Enemy")
            {
                PlayerPos.position = PlayerPos.position;                
                EnemyInvis.SetDestination(PlayerPos.position);
                anim.Play("Walk");
            }
            else if (gameObject.tag == "Freeze")
            {
                StartCoroutine("Stun");
            }
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
            EnemyInvis.SetDestination(transform.position);
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
