using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GallinaEvadeState : IState
{
    FiniteStateMachine _fsm;
    Gallina _gallina;

    public GallinaEvadeState(FiniteStateMachine fsm, Gallina r)
    {
        _fsm = fsm;
        _gallina = r;
    }

    public void OnEnter()
    {
        //Debug.Log("gallina - entre a evade");
    }

    public void OnUpdate()
    {
        _gallina.RotateAccordingly();
        WalkAwayFromPlayer();
        if (Vector3.Distance(_gallina._player.transform.position, _gallina.transform.position) > _gallina.exitDistance)
        {
            _fsm.ChangeState(State.GallinaWalk);
        }
    }

    public void OnExit()
    {
        //Debug.Log("salgo de walk");
        //Debug.Log("gallina - entre a walk");
    }

    public void WalkAwayFromPlayer()
    {
        Vector3 dir = _gallina._player.transform.position - _gallina.transform.position;
        dir.y = 0;
        _gallina.transform.position += _gallina.Speed * 3 * Time.deltaTime * -dir.normalized;
    }
}
