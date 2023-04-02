using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSolapa : TriggerScript
{
    [SerializeField]
    Solapa solapaAfectada;

    [SerializeField]
    string tooltipTextToShow;

    private void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, InteractWithSolapa);
    }

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

    public void InteractWithSolapa(params object[] parameter)
    {
        if (triggerBool)
        {
            solapaAfectada.CambiarEstado();
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, InteractWithSolapa);
        }
    }


}
