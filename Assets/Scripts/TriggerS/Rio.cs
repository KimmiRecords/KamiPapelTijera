using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rio : TriggerScript
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            OnEnterBehaviour();
            MojarPlayer(other);
        }
    }

    public void MojarPlayer(Collider other)
    {
        if (other.gameObject.GetComponent<IMojable>() != null)
        {
            IMojable player = other.gameObject.GetComponent<IMojable>();
            player.GetWet();
        }
    }
}
