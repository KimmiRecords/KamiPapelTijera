using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : TriggerScript
{
    [TextAreaAttribute][SerializeField]
    string[] textos;

    public override void OnEnterBehaviour()
    {
        print("trigger dialogue - on enter behaviour");
        DialogueManager.instance.ShowDialogue(textos);
    }
}
