using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStarterTrigger : TriggerScript
{
    [SerializeField] GameObject tutorial;
    bool alreadyTriggered = false;

    public override void OnEnterBehaviour(Collider other)
    {
        base.OnEnterBehaviour(other);
        if (!alreadyTriggered)
        {
            tutorial.SetActive(true);
            alreadyTriggered = true;
        }
    }
}
