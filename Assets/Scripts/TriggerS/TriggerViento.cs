using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerViento : TriggerScript
{
    [SerializeField] float windForce = 10;
    [SerializeField] Vector3 windDirection = Vector3.back; 

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        other.GetComponent<IWindable>()?.StartAffectedByWind(windForce, windDirection);
        //AudioManager.instance.PlayByName("viento_loop");
    }

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<IWindable>()?.GetAffectedByWind(windForce, windDirection);
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        other.GetComponent<IWindable>()?.EndAffectedByWind();
        //AudioManager.instance.StopByName("viento_loop");
    }
}
