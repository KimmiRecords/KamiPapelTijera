using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAbuelaDropoff : TriggerScript
{
    public override void OnEnterBehaviour(Collider other)
    {
        //base.OnEnterBehaviour(other);
        EventManager.Trigger(Evento.OnAbuelaDropoff, transform.position);
    }
}
