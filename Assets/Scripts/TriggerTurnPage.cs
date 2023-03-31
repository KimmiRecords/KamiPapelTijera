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
            triggerBool = true;
            print("entroel player");
            TooltipManager.instance.ShowTooltip(tooltipTextToShow);
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (other.gameObject == requiredGameObject)
        {
            triggerBool = false;
            print("se salio el player");
            TooltipManager.instance.HideTooltip();

        }
    }

}
