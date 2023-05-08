using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_FollowPlayerState : IState
{
    FiniteStateMachine _fsm;
    NPC _npc;


    public NPC_FollowPlayerState(FiniteStateMachine fsm, NPC npc)
    {
        _fsm = fsm;
        _npc = npc;

    }

    public void OnEnter()
    {
        Debug.Log("[NPC] entro al follow player state");
    }
    public void OnUpdate()
    {
        //Debug.Log("[NPC]  state");

        _npc.AddForce(_npc.FollowPlayer());

        if (!_npc.isFollowing)
        {
            _fsm.ChangeState(State.NPC_Idle);
        }

    }
    public void OnExit()
    {
        Debug.Log("[NPC] salgo del followplayer state");
    }
}
