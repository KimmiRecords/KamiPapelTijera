using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : TriggerScript
{
    [SerializeField]
    string soundName;

    public override void OnEnterBehaviour()
    {
        //print("entro el player");
        triggerBool = true;
        TooltipManager.instance.ShowTooltip(tooltipTextToShow);
        
        if (soundName == "4S_MarimbaLoopConPiano")
        {

            AudioManager.instance.PlayOnEnd("4S_MarimbaLoop", "4S_MarimbaLoopConPiano");
        }
        else
        {
            AudioManager.instance.PlayByName(soundName);
        }

        Destroy(gameObject);
    }

}
