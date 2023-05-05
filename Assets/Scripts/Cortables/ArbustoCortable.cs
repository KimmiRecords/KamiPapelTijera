using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbustoCortable : MonoBehaviour, ICortable
{
    public void GetCut(float dmg)
    {
        //print("cortaste este arbusto");
        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
        Destroy(gameObject);
    }
}
