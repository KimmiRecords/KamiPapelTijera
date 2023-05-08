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
    }
    public void OnUpdate()
    {
        //Debug.Log("[NPC]  state");

        _abuela.AddForce(_abuela.Arrive(_abuela.dropoffPoint));

        if (Vector3.Distance(_abuela.transform.position, _abuela.dropoffPoint) < 3)
        {
            _abuela.velocity = Vector3.zero;
            _fsm.ChangeState(State.Abuela_Idle);
        }
    }
    public void OnExit()
    {
        //Debug.Log("[NPC] salgo del dropoff state");
    }
}
