using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleDialogueManager : MonoBehaviour
{
    private GameObject dialoguePanel;
    public string npcName = "Capsule NPC"; //in the project the name must be changed to some unique name
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDialoguePanel()
    {
        dialoguePanel.SetActive(true);
    }

    public void CloseDialoguePanel()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartCommunication()
    {
        anim.SetBool("Dialogue", true);
    }

    public void FinishCommunication()
    {
        anim.SetBool("Dialogue", false);
    }
}
