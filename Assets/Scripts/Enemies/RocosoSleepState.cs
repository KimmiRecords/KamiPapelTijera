using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocosoSleepState : IState
{
    FiniteStateMachine _fsm;
    Rocoso _rocoso;

    public RocosoSleepState(FiniteStateMachine fsm, Rocoso r)
    {
        _fsm = fsm;
        _rocoso = r;
    }

    public void OnEnter()
    {
        _rocoso.anim.SetTrigger("isEepy");
    }

    public void OnUpdate()
    {
        if (_rocoso.PlayerIsInViewRange())
        {
            _fsm.ChangeState(State.RocosoStart);
        }

        if (_rocoso.isDead)
        {
            _fsm.ChangeState(State.RocosoDeath);
        }
    }

    public void OnExit()
    {
        //Debug.Log("rocoso salgo de sleep");
    }
}
