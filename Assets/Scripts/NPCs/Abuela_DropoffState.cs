using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abuela_DropoffState : IState
{
    FiniteStateMachine _fsm;
    NPC_Abuela _abuela;

    public Abuela_DropoffState(FiniteStateMachine fsm, NPC_Abuela npc)
    {
        _fsm = fsm;
        _abuela = npc;
    }

    public void OnEnter()
    {
        //Debug.Log("[NPC] entro al dropoff state");
        _abuela.anim.SetBool("IsWalking", true);
    }
    public void OnUpdate()
    {
        //Debug.Log("[NPC]  state");

        _abuela.AddForce(_abuela.Arrive(_abuela.dropoffPoint.position));

        if (Vector3.Distance(_abuela.transform.position, _abuela.dropoffPoint.position) < 3)
        {
            _abuela.velocity = Vector3.zero;
            _abuela.isDropoff = false;
            _fsm.ChangeState(State.Abuela_Idle);
        }
    }
    public void OnExit()
    {
        //Debug.Log("[NPC] salgo del dropoff state");
    }
}
