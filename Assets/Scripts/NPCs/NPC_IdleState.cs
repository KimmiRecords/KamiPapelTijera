using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_IdleState : IState
{
    FiniteStateMachine _fsm;
    NPC _npc;

    public NPC_IdleState(FiniteStateMachine fsm, NPC npc)
    {
        _fsm = fsm;
        _npc = npc;
    }


    public void OnEnter()
    {
        Debug.Log("[NPC] entro al idle state");
    }
    public void OnUpdate()
    {
        //Debug.Log("[NPC] entro al idle state");
        if (_npc.isFollowing)
        {
            _fsm.ChangeState(State.NPC_FollowPlayer);
        }

    }

    public void OnExit()
    {
        Debug.Log("[NPC] salgo del idle state");
    }


}
