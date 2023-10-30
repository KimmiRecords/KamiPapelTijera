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
            _fsm.ChangeState(State.RocosoAttack);
        }

        if (!_rocoso.PlayerIsInViewRange())
        {
            //Debug.Log("walk: me paso a sleep");
            _fsm.ChangeState(State.RocosoSleep);
        }

        if (_rocoso.isDead)
        {
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
        _rocoso.myRigidbody.AddForce(_rocoso.Speed * Time.deltaTime * dir.normalized, ForceMode.VelocityChange);
    }
}
