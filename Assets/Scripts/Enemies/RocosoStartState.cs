using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocosoStartState : IState
{
    FiniteStateMachine _fsm;
    Rocoso _rocoso;

    public RocosoStartState(FiniteStateMachine fsm, Rocoso r)
    {
        _fsm = fsm;
        _rocoso = r;
    }

    public void OnEnter()
    {
        Debug.Log("entre a start");
        _rocoso.anim.SetBool("isStart", true);
    }

    public void OnUpdate()
    {
        if (_rocoso.startAnimationHasFinished)
        {
            _fsm.ChangeState(State.RocosoWalk);
        }
    }

    public void OnExit()
    {
        Debug.Log("salgo de start");
    }
}
