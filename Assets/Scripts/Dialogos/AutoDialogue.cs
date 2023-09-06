using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogue : MonoBehaviour
{
    //cuando se lo pedis, arranca a dialogar

    [SerializeField] DialogueSO dialogue;

    public void StartDialogue()
    {
        //print("auto dialogue - start");
        DialogueManager.Instance.ShowDialogue(dialogue);
    }
}