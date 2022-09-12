using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargeter : MonoBehaviour
{
    private Transform player;
    private RaycastHit hit;
    public float attackRange = 300.0F;
    public string enemy;
    public bool gunTrigger;
    public GameObject soldiermoving;

    SoldierMovWithModes soldierMov;


    void Awake()
    {
        soldierMov = soldiermoving.GetComponent<SoldierMovWithModes>();
        player = transform;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int layerMask = 1 << 8;
        // Debug.DrawLine(this.transform.position, this.transform.forward, Color.white, 75.0f);
        if (Physics.Raycast(player.position, Vector3.forward, out hit, attackRange))
        {

            //if (hit.collider.CompareTag(enemy))
            //{
            //    //AIShooting.gunTrigger = true;
            //    gunTrigger = true;
            //}
            if (soldierMov.shootEnemy)
            {
                gunTrigger = true;
            }
        }
        else
        {
            //AIShooting.gunTrigger = false;
            gunTrigger = false;
        }
    }
}
