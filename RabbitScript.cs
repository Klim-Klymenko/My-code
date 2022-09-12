using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitScript : MonoBehaviour
{
    //Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;
    public GameObject[] waypoints;
    GameObject currentWaypoint;
    int waypointIndex = 0;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentWaypoint = waypoints[waypointIndex];
        nav.SetDestination(currentWaypoint.transform.position);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Waypoint")
        {
            waypointIndex++;
            // Debug.Log("Next position!");

            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
            currentWaypoint = waypoints[waypointIndex];
            nav.SetDestination(currentWaypoint.transform.position);
        }
    }
}