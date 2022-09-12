using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceletonAttackWithModes : MonoBehaviour
{
    public float timeBetweenAttacks1 = 1.5f;
    public int attackDamage1 = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;//-
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;



    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks1 && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        //-
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
        //-
    }


    void Attack()
    {
        timer = 0f;

        anim.SetTrigger("Attack");//

        //-
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage1);
        }
        //-
    }
}
