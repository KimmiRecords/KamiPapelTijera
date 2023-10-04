using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerViento : TriggerScript
{
    [SerializeField] float windForce = 10;
    [SerializeField] Vector3 windDirection = Vector3.back; 

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<IWindable>()?.GetAffectedByWind(windForce, windDirection);
    }
}
