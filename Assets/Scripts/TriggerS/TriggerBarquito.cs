using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBarquito : TriggerScript
{
    [SerializeField]
    BarquitoBehaviour esteBarco;

    ITransportable playerRef;

    public override void OnEnterBehaviour(Collider other)
    {
        base.OnEnterBehaviour(other);
        esteBarco.playerIsInside = triggerBool;

        if (other.GetComponent<ITransportable>() != null)
        {
            Debug.Log("obtengo refe del player transportable");
            playerRef = other.GetComponent<ITransportable>();
        }
    }

    public override void OnExitBehaviour()
    {
        base.OnExitBehaviour();
        esteBarco.playerIsInside = triggerBool;
    }

    void OnTriggerStay(Collider other)
    {
        if (esteBarco.playerIsInside)
        {
            playerRef.Transport(esteBarco.velocity);
            //Debug.Log("barquito velocity = " + esteBarco.velocity);
        }
    }
}
