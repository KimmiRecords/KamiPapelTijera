using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGallina : TriggerScript
{
    [SerializeField] GallinaAI _thisGallina;

    public override void OnEnterBehaviour(Collider other)
    {
        _thisGallina.playerIsInRange = true;
        _thisGallina._player = other.GetComponent<Player>();
    }

    public override void OnExitBehaviour()
    {
        _thisGallina.playerIsInRange = false;
    }
}
