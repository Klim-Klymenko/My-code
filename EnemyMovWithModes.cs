using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovWithModes : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;//-
    EnemyHealth enemyHealth;//-
    NavMeshAgent nav;
    public GameObject[] waypoints;
    GameObject currentWaypoint;
    public int waypointIndex = 0;//--
    Animator anim;

    private float walkSpeed = 3.5f;
    private float runSpeed = 5f;
    private float stayAtWayPointTime = 2.0f;
    public bool stayAtWayPoint = false;//--
    public string currentDestination = "";//--
    public bool enemyDead = false;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();//-
        enemyHealth = GetComponent<EnemyHealth>();//-
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentWaypoint = waypoints[waypointIndex];
        nav.SetDestination(currentWaypoint.transform.position);
        currentDestination = nav.destination.ToString();//added to control current destination of the enemy
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Waypoint")
        {
            //Debug.Log("Coroutine Start");
            anim.SetTrigger("PlayerDead");//
            StartCoroutine(WaypointPause());
            //Debug.Log("Coroutine Finish");
            waypointIndex++;
            // Debug.Log("Next position!");

            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
            currentWaypoint = waypoints[waypointIndex];
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.position);
        //--added to control enemy active or not 
        if (enemyHealth.currentHealth <= 0)
        {
            enemyDead = true;
        }
        //--
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !enemyDead)
        {
            //nav.SetDestination(player.position);//-
            //nav.SetDestination(player.position);
            //anim.SetBool("PlayerInRange", true);
            //nav.speed = runSpeed;
            //option1
            if (distance < 10.0f && distance > 1.0f)
            {
                //option4
                nav.SetDestination(player.position);
                currentDestination = nav.destination.ToString();//added to control current destination of the enemy
                anim.SetBool("PlayerInRange", true);
                nav.speed = runSpeed;
            }
            else if (distance < 1.0f && distance > 0.0f)
            {
                nav.SetDestination(player.position);
                currentDestination = nav.destination.ToString();//added to control current destination of the enemy
                anim.SetBool("PlayerInRange", false);
                nav.speed = walkSpeed;
            }
            else
            {
                if (!stayAtWayPoint)
                {
                    nav.SetDestination(currentWaypoint.transform.position);
                    currentDestination = nav.destination.ToString();//added to control current destination of the enemy
                    anim.SetBool("PlayerInRange", false);
                    nav.speed = walkSpeed;
                }
                else
                {
                    nav.SetDestination(currentWaypoint.transform.position);
                    currentDestination = nav.destination.ToString();//added to control current destination of the enemy
                    anim.SetBool("PlayerInRange", false);
                    nav.speed = 0.0f;
                }
                //nav.SetDestination(currentWaypoint.transform.position);
                //anim.SetBool("PlayerInRange", false);
                //nav.speed = walkSpeed;
            }
        }
        else
        {
            nav.enabled = false;
        }
        //option2
        //if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        //    nav.SetDestination(player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}

        //option3
        //nav.SetDestination(player.position);
    }

    //stay some time at the waypoint
    IEnumerator WaypointPause()
    {

        //Debug.Log("Stay in waypoint area...");

        //anim.SetTrigger("PlayerDead");//
        stayAtWayPoint = true;

        yield return new WaitForSeconds(stayAtWayPointTime);
        anim.SetTrigger("WaypointPauseFinished");//
        stayAtWayPoint = false;


    }
}

