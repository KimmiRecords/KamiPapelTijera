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
        _rocoso.anim.SetBool("isWalk", true);

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


        if (Vector3.Distance(_rocoso.target, _rocoso.transform.position) < 10)
        {
            //Debug.Log("ONUPDATE - me cambio a attack");
            _fsm.ChangeState(State.RocosoAttack);
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
            Debug.Log("WALK METHOD - me cambio a attack");
            _fsm.ChangeState(State.RocosoAttack);
        }
    }
}
