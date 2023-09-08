using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : TriggerScript
{
    //este es un tipo de triggerscript que solo muestra texto. 
    [SerializeField] bool isOneTimeOnly;
    bool wasShown = false;

    public override void OnEnterBehaviour(Collider other)
    {
        //print("entro el player");

        if (isOneTimeOnly && wasShown)
        {
            return;
        }
        else
        {
            triggerBool = true;
            TooltipManager.instance.ShowTooltip(tooltipTextToShow, postItColor);
            wasShown = true;
        }
    }
}
