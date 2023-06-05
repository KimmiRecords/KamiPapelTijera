using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbustoCortable : MonoBehaviour, ICortable
{
    public int paperDropAmount = 1;
    public void GetCut(float dmg)
    {
        //print("cortaste este arbusto");
        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
        EventManager.Trigger(Evento.OnCortableDropsPaper, paperDropAmount);
        Destroy(gameObject);

        //en vez de destroy, habria que cambiar el sprite a arbustocortado
        //despues de un rato re-crece (vuelve a estar entero y ser cortable)
    }
}
