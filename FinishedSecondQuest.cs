using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedSecondQuest : MonoBehaviour
{
    int counter;
    public GameObject portal;
    public Text questText2;
    public Text finishedQuest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MedKit")
        {
            counter++;
            Debug.Log(counter);
        }
        if (collision.gameObject.tag == "Canister 2")
        {
            counter++;
            Debug.Log(counter);
        }
        if (collision.gameObject.tag == "SimpleItem 3")
        {
            counter++;
            Debug.Log(counter);
        }
        if (collision.gameObject.tag == "SimpleItem 2")
        {
            counter++;
            Debug.Log(counter);
        }
        if (collision.gameObject.tag == "SimpleItem")
        {
            counter++;
            Debug.Log(counter);
        }
         if (counter == 5)
        {
            portal.SetActive(false);
            questText2.gameObject.SetActive(false);
            finishedQuest.gameObject.SetActive(true);
        }
    }
}
