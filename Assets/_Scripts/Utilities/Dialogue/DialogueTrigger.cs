using System.Threading;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    // public Tree tree;
    public void TriggerDialogue ()
    {
        // tree = FindAnyObjectByType<Tree>();

        // if (tree.CountDie() == 1)
        // {
        //     FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        // }
        // {
        //     FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        // }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    // public int CountDie()
    // {
    //     return tree.CountDie();
    // }
   
}