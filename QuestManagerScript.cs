using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestManagerScript : MonoBehaviour
{
    public GameObject portal;
    public Text questText2;
    public EnemyHealth eH;
    public GameObject arrow;
    public Text questText;

    public void Quest1()
    {
        arrow.SetActive(true);
        questText.gameObject.SetActive(true);
    }
    public void Update()
    {
        if (eH.currentHealth <= 0)
        {
            arrow.SetActive(false);
            questText.gameObject.SetActive(false);
        }
    }
    public void Quest2()
    {
        questText2.gameObject.SetActive(true);
        portal.SetActive(true);
    }
}