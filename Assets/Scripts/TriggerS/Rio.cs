using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rio : TriggerScript
{
    //este no muestra el tooltip, solo moja

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<IMojable>() != null)
        {
            IMojable mojable = other.gameObject.GetComponent<IMojable>();
            mojable.GetWet();
        }
    }

    //public override void OnEnterBehaviour(Collider other)
    //{
    //    triggerBool = true;
    //    MojarPlayer(other);
    //}

    //public void MojarPlayer(Collider other)
    //{
    //    if (other.gameObject.GetComponent<IMojable>() != null)
    //    {
    //        IMojable player = other.gameObject.GetComponent<IMojable>();
    //        player.GetWet();
    //    }
    //}
}
