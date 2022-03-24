using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInvisable : MonoBehaviour
{

    public Transform PlayerPos;
    NavMeshAgent EnemyInvis;
    Animator animator;
    float distance;
    public float visible;
    SkinnedMeshRenderer Visibility;
    int Spawnstate;
    int Spawntype;
    bool canAttack;
    int enemyHealth;
    bool isVisible;

    // Use this for initialization
    void Start()
    {      
        canAttack = true;
        enemyHealth = 1 + RoundManager.healthMod;
        EnemyInvis = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Visibility = GetComponentInChildren<SkinnedMeshRenderer>();
        Visibility.enabled = false;

        visible = 10f;
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
        if (gameObject.tag == "Enemy")
        {
            PlayerPos.position = PlayerPos.position;
            distance = Vector3.Distance(PlayerPos.position, transform.position);
            EnemyInvis.SetDestination(PlayerPos.position);
            animator.Play("Walk");
        }
        else if (gameObject.tag == "Freeze")
        {
            EnemyInvis.SetDestination(transform.position);
            Visibility.enabled = true;
            StartCoroutine("Stun");
        }

        if (enemyHealth <= 0)
        {
            
            if(Spawntype >= 1)
            {
                PlayerStats.soulCount += 5 + PlayerStats.soulMod;
            }
            else
            {
                PlayerStats.soulCount += 2 + PlayerStats.soulMod;
            }
            
            Destroy(gameObject);
        }

        if (distance > visible)
        {
            Visibility.enabled = false;
            isVisible = false;
        }
        else
        {
            Visibility.enabled = true;
            if(isVisible == false)
            {
                isVisible = true;
                Soundsystem.Invis = true;
            }

        }

        if (canAttack && distance < 5f && gameObject.tag == "Enemy")
        {
            
            StartCoroutine("AttackRoutine");
            Soundsystem.attack = true;
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
        yield return new WaitForSeconds(0.3f);
        animator.Play("Attack");

        PlayerStats.soulCount -= Enemy1AI.enemyDamage;

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

        yield return new WaitForSeconds(1.5f);
        canAttack = true;
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(5f);
        gameObject.tag = "Enemy";
    }
}


