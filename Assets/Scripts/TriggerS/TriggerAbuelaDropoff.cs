using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAbuelaDropoff : TriggerScript
{
    [SerializeField]
    NPC_Abuela abuela;
    [SerializeField]
    Transform dropOffPoint;

    public override void OnEnterBehaviour(Collider other)
    {
        if (abuela.isFollowing)
        {
            EventManager.Trigger(Evento.OnAbuelaDropoff, dropOffPoint);
            //AudioManager.instance.StopByName("4S_MarimbaLoopConPiano");
            AudioManager.instance.PlayByName("MagicSuccess", 0.6f);
            //AudioManager.instance.PlayOnEnd("QuestCompleted", "4S_MarimbaLoop");
            base.OnEnterBehaviour(other);
        }
    }
}
