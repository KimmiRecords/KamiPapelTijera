using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocosoWalkState : IState
{
    FiniteStateMachine _fsm;
    Rocoso _rocoso;

    public RocosoWalkState(FiniteStateMachine fsm, Rocoso r)
    {
        _fsm = fsm;
        _rocoso = r;
    }

    public void OnEnter()
    {
        //Debug.Log("entre a walk");
        _rocoso.anim.SetTrigger("isWalks");

    }

    public void OnUpdate()
    {
        WalkTowardsPlayer();

        if (_rocoso.target.x > _rocoso.transform.position.x) //roto al rocoso
        {
            _rocoso.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            _rocoso.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (_rocoso.DistanceToPlayer() < _rocoso.enterAttackRange)
        {
            //Debug.Log("ONUPDATE - me cambio a attack");
            _fsm.ChangeState(State.RocosoAttack);
        }

        if (!_rocoso.PlayerIsInViewRange())
        {
            //Debug.Log("ONUPDATE - me cambio a attack");
            _fsm.ChangeState(State.RocosoSleep);
        }

        if (_rocoso.isDead)
        {
            //Debug.Log("Walk - ONUPDATE - me cambio a death porque me mori");
            _fsm.ChangeState(State.RocosoDeath);
        }
    }


    public void OnExit()
    {
        //Debug.Log("salgo de walk");

    }

    public void WalkTowardsPlayer()
    {
        Vector3 dir = _rocoso.target - _rocoso.transform.position;
        dir.y = 0;
        //_rocoso.transform.forward = dir;
        _rocoso.transform.position +=  _rocoso.Speed * Time.deltaTime * dir.normalized;

        if (dir.magnitude < 0.1f)
        {
            //Debug.Log("WALK METHOD - me cambio a attack");
            _fsm.ChangeState(State.RocosoAttack);
        }
    }
}
