using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogue : MonoBehaviour
{
    //cuando se lo pedis, arranca a dialogar

    [SerializeField]
    Dialogue dialogue;

    public void StartDialogue()
    {
        //print("auto dialogue - start");
        DialogueManager.instance.ShowDialogue(dialogue);
    }
}