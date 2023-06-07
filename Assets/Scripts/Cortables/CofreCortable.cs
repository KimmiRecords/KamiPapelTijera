using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreCortable : MonoBehaviour, ICortable
{
    bool wasCut = false;
    public void GetCut(float dmg)
    {
        if (!wasCut)
        {
            //print("cortaste el cofre. ganaste 15 pesos");
            EventManager.Trigger(Evento.OnCortableDropsPaper, 5);
            AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
            AudioManager.instance.PlayByName("MagicSuccess", 1.5f);
            Destroy(gameObject);
            wasCut = true;
        }
    }
}
