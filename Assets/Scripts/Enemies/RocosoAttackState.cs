using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocosoAttackState : IState
{
    FiniteStateMachine _fsm;
    Rocoso _rocoso;

    public RocosoAttackState(FiniteStateMachine fsm, Rocoso r)
    {
        _fsm = fsm;
        _rocoso = r;
    }

    public void OnEnter()
    {
        //Debug.Log("entre a attack");
        _rocoso.isHitting = true;
        _rocoso._hitBox.didHit = false;
        _rocoso.anim.SetTrigger("isAttacks");
    }

    public void OnUpdate()
    {
        if (_rocoso.DistanceToPlayer() > _rocoso.exitAttackRange)
        {
            Debug.Log("attack: me paso a walk");
            _fsm.ChangeState(State.RocosoWalk);
        }

        if (!_rocoso.isHitting)
        {
            //Debug.Log("ONUPDATE - me cambio a walk xq no pegue");
            _fsm.ChangeState(State.RocosoWalk);
        }

        if (_rocoso.isDead)
        {
            //Debug.Log("attack - ONUPDATE - me cambio a death porque me mori");
            _fsm.ChangeState(State.RocosoDeath);
        }
    }

    public void OnExit()
    {
        //Debug.Log("salgo de attack");
        //_rocoso.isHitting = false;
    }
}
