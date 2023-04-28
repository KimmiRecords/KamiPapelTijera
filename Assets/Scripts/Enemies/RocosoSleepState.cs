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
        Debug.Log("entre a sleep");
        //_rocoso.RocosoCamina();

    }

    public void OnUpdate()
    {
        if (_rocoso.wasAwoken)
        {
            _fsm.ChangeState(State.RocosoStart);
        }
    }

    public void OnExit()
    {
        Debug.Log("salgo de sleep");
    }
}
