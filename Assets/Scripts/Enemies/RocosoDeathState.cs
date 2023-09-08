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

        float cryPitch = 1f;
        if (_rocoso.endsEncounter)
        {
            cryPitch = 0.5f;
        }
        AudioManager.instance.PlayByName("RocosoCry", cryPitch, 0.1f);
    }

    public void OnUpdate()
    {
        
    }

    public void OnExit()
    {

    }
}
