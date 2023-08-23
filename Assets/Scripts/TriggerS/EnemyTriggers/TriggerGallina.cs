using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGallina : TriggerScript
{
    [SerializeField]
    Gallina _thisGallina;

    public override void OnEnterBehaviour(Collider other)
    {
        //print("el player entro a mi trigger, el rocoso debe despertar");
        _thisGallina.playerIsInRange = true;
        _thisGallina._player = other.GetComponent<Player>();
    }

    public override void OnExitBehaviour()
    {
        _thisGallina.playerIsInRange = false;
    }
}
