using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSolapa : TriggerScript
{
    [SerializeField]
    Solapa solapaAfectada;

    public override void Interact(params object[] parameter)
    {
        if (triggerBool)
        {
            solapaAfectada.CambiarEstado();
        }
    }
}
