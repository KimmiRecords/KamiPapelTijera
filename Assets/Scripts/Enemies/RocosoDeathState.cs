using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocosoDeathState : IState
{
    FiniteStateMachine _fsm;
    Rocoso _rocoso;

    public RocosoDeathState(FiniteStateMachine fsm, Rocoso r)
    {
        _fsm = fsm;
        _rocoso = r;
    }

    public void OnEnter()
    {
        Debug.Log("entre a death");
        _rocoso.anim.SetBool("isDead", true);
    }

    public void OnUpdate()
    {
        
    }

    public void OnExit()
    {

    }
}
