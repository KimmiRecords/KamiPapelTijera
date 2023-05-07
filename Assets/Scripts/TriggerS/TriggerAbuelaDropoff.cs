using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAbuelaDropoff : TriggerScript
{
    [SerializeField]
    NPC_Abuela abuela;
    public override void OnEnterBehaviour(Collider other)
    {
        //base.OnEnterBehaviour(other);
        if (abuela.isFollowing)
        {
            EventManager.Trigger(Evento.OnAbuelaDropoff, transform.position);
        }
    }
}
