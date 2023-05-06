using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : TriggerScript
{

    [SerializeField]
    bool burnAfterReading;
    [TextAreaAttribute][SerializeField]
    string[] textos;

    public override void OnEnterBehaviour(Collider other)
    {
        //print("trigger dialogue - on enter behaviour");
        DialogueManager.instance.ShowDialogue(textos);

        if (burnAfterReading)
        {
            Destroy(this);
        }
    }

    //aca deberia agregar el interact.
    //asi deja de triggerear por enter, pero queda con E
}
