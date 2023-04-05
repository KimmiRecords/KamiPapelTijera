using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTurnPage : TriggerScript
{
    [SerializeField]
    string tooltipTextToShow;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == requiredGameObject)
        {
            OnEnterBehaviour();
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (other.gameObject == requiredGameObject)
        {
            OnExitBehaviour();
        }
    }

    public override void OnEnterBehaviour()
    {
        triggerBool = true;
        //print("entroel player");
        TooltipManager.instance.ShowTooltip(tooltipTextToShow);
    }

    public override void OnExitBehaviour()
    {
        triggerBool = false;
        //print("se salio el player");
        TooltipManager.instance.HideTooltip();
    }

}
