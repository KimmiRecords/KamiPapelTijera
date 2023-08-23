using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abuela_FollowPlayerState : IState
{
    FiniteStateMachine _fsm;
    NPC_Abuela _abuela;
    public Abuela_FollowPlayerState(FiniteStateMachine fsm, NPC_Abuela npc)
    {
        _fsm = fsm;
        _abuela = npc;
    }

    public void OnEnter()
    {
        //Debug.Log("[NPC] entro al follow player state");
        _abuela.anim.SetBool("IsWalking", true);

    }
    public void OnUpdate()
    {
        //Debug.Log("[NPC]  state");

        _abuela.AddForce(_abuela.FollowPlayer());

        if (!_abuela.isFollowing)
        {
            _fsm.ChangeState(State.NPC_Idle);
        }

        if (_abuela.isDropoff)
        {
            _fsm.ChangeState(State.Abuela_Dropoff);
        }
    }
    public void OnExit()
    {
        //Debug.Log("[NPC] salgo del followplayer state");
        _abuela.isFollowing = false;
        _abuela.anim.SetBool("IsWalking", false);
    }
}
