using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStarterTrigger : TriggerScript
{
    //cuando el jugador pisa este trigger, se activa el tutorial

    [SerializeField] GameObject tutorialObject;
    bool alreadyTriggered = false;

    public override void OnEnterBehaviour(Collider other)
    {
        base.OnEnterBehaviour(other);
        if (!alreadyTriggered)
        {
            tutorialObject.SetActive(true);
            alreadyTriggered = true;
        }
    }
}
