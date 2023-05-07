using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abuela_IdleState : IState
{
    //se podria hacer herencia de los states npc y abuela??

    FiniteStateMachine _fsm;
    NPC_Abuela _abuela;

    public Abuela_IdleState(FiniteStateMachine fsm, NPC_Abuela npc)
    {
        _fsm = fsm;
        _abuela = npc;
    }


    public void OnEnter()
    {
        //Debug.Log("[NPC] entro al idle state");
    }
    public void OnUpdate()
    {
        //Debug.Log("[NPC] entro al idle state");
        if (_abuela.isFollowing)
        {
            _fsm.ChangeState(State.Abuela_FollowPlayer);
        }
    }

    public void OnExit()
    {
        //Debug.Log("[NPC] salgo del idle state");
    }
}
