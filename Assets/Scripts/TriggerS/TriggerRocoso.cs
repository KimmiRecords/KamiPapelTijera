using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRocoso : TriggerScript
{
    [SerializeField]
    Rocoso _thisRocoso;

    Player _player;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            _player = other.GetComponent<Player>();
            OnEnterBehaviour();
        }
    }

    public override void OnEnterBehaviour()
    {
        print("el player entro a mi trigger, el rocoso debe despertar");
        _thisRocoso.RocosoDespierta(_player);
    }
}
