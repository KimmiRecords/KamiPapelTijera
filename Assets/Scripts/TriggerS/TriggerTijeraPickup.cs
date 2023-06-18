using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTijeraPickup : TriggerScript
{
    public override void Interact(params object[] parameter)
    {
        if (triggerBool)
        {
            EventManager.Trigger(Evento.OnPlayerGetTijera);
            AudioManager.instance.PlayByName("Pickup", 0.7f);
            AudioManager.instance.PlayByName("Pickup", 1.4f);
            AudioManager.instance.PlayByName("MagicSuccess", 0.7f);

            OnExitBehaviour();
            Destroy(gameObject);
        }
    }
}
