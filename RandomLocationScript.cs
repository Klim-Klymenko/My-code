using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(Random.Range(0.0f, 1000.0f), 0, Random.Range(0.0f, 1000.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombi" || other.gameObject.tag == "Predator" || other.gameObject.tag == "Rabbit")
        {
            this.transform.position = new Vector3(Random.Range(1f, 999f), 0, Random.Range(1f, 999f));
        }
    }
}