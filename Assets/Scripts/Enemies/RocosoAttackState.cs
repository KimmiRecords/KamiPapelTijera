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
        _rocoso.anim.SetBool("isWalk", false);
        _rocoso.anim.SetBool("isAttack", true);
        _rocoso.isHitting = true;
        _rocoso._hitBox.didHit = false;
    }

    public void OnUpdate()
    {
        if (Vector3.Distance(_rocoso.target, _rocoso.transform.position) > _rocoso.disengageRange)
        {
            //Debug.Log("ONUPDATE - me cambio a walk xq ta re lejos");
            _fsm.ChangeState(State.RocosoWalk);
        }

        if (!_rocoso.isHitting)
        {
            //Debug.Log("ONUPDATE - me cambio a walk xq no pegue");
            _fsm.ChangeState(State.RocosoWalk);
        }

        if (_rocoso.isDead)
        {
            Debug.Log("attack - ONUPDATE - me cambio a death porque me mori");
            _fsm.ChangeState(State.RocosoDeath);
        }
    }

    public void OnExit()
    {
        //Debug.Log("salgo de attack");
        //_rocoso.isHitting = false;
        _rocoso.anim.SetBool("isAttack", false);
    }
}
