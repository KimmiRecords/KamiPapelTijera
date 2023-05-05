using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRocoso : TriggerScript
{
    [SerializeField]
    Rocoso _thisRocoso;

    Player _player;

    public override void OnEnterBehaviour(Collider other)
    {
        _player = other.GetComponent<Player>();
        //print("el player entro a mi trigger, el rocoso debe despertar");
        _thisRocoso.RocosoDespierta(_player);
    }
}
