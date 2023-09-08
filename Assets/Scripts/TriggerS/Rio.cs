using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rio : TriggerScript
{
    //este no muestra el tooltip, solo moja
    [SerializeField] float wetDamage = 20;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<IMojable>() != null)
        {
            Debug.Log("rio: mojo a alguien");
            IMojable mojable = other.gameObject.GetComponent<IMojable>();
            mojable.GetWet(wetDamage);
        }
    }


    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.gameObject.GetComponent<IMojable>() != null)
        {
            IMojable mojable = other.gameObject.GetComponent<IMojable>();
            mojable.StopGettingWet();
        }
    }

    //public override void OnEnterBehaviour(Collider other)
    //{
    //    triggerBool = true;
    //    MojarPlayer(other);
    //}

}
