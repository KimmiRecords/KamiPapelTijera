using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbustoCortable : MonoBehaviour, ICortable
{
    //por ahora los arbustos quedan cortados para siempre

    public int paperDropAmount = 1;
    public void GetCut(float dmg)
    {
        print("cortaste este arbusto");
        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
        AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");
        EventManager.Trigger(Evento.OnCortableDropsPaper, paperDropAmount); //esto no va a ser asi cuando pase el papel al levelmanager
        Destroy(this.gameObject);
        
    }
}
