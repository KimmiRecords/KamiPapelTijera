using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogue : MonoBehaviour
{
    //cuando se lo pedis, arranca a dialogar

    [TextAreaAttribute]
    [SerializeField]
    string[] textos;

    public void StartDialogue()
    {
        //print("auto dialogue - start");
        DialogueManager.instance.ShowDialogue(textos);
    }
}
