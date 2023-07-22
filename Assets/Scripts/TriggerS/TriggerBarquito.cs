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

        if (playerRef == null && other.GetComponent<ITransportable>() != null)
        {
            Debug.Log("obtengo refe del player transportable");
            playerRef = other.GetComponent<ITransportable>();
            //playerRef.AttachToTransporter(esteBarco.transform);
        }
    }

    public override void Interact(params object[] parameter)
    {
        if (triggerBool)
        {
            esteBarco.playerIsInside = triggerBool;
        }
    }

    public override void OnExitBehaviour()
    {
        base.OnExitBehaviour();
        esteBarco.playerIsInside = triggerBool;
    }

    private void OnTriggerStay(Collider other)
    {
        if (esteBarco.playerIsInside)
        {
            playerRef.Transport(esteBarco.velocity);
        }
    }
}
