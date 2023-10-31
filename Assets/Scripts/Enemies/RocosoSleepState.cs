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
        _rocoso.playerEnteredWakeUpCollider = false;
        _rocoso.startAnimationHasFinished = false;
        _rocoso.anim.SetTrigger("isEepy");
    }

    public void OnUpdate()
    {
        if (_rocoso.playerEnteredWakeUpCollider)
        {
            //Debug.Log("sleep: me paso a start");
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
