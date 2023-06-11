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
        LevelManager.instance.AddResource(ResourceType.papel, paperDropAmount);
        Destroy(this.gameObject);
        
    }
}
