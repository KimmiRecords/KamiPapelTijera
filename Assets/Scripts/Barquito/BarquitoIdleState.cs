using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarquitoIdleState : IState
{
    FiniteStateMachine _fsm;
    BarquitoBehaviour _barco;
    public BarquitoIdleState(FiniteStateMachine fsm, BarquitoBehaviour barco)
    {
        _fsm = fsm;
        _barco = barco;
    }

    public void OnEnter()
    {
        //Debug.Log("entro a idle state");
    }

    public void OnExit()
    {
        //Debug.Log("salgo del idle state");
    }

    public void OnUpdate()
    {
        if (_barco.playerIsInside)
        {
            _fsm.ChangeState(State.BarquitoMoving);
        }
    }
}
