using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rio : TriggerScript
{
    public override void OnEnterBehaviour()
    {
        base.OnEnterBehaviour();
        if (requiredGameObject.GetComponent<IMojable>() != null)
        {
            IMojable player = requiredGameObject.GetComponent<IMojable>();
            player.GetWet();
        }
    }
}
