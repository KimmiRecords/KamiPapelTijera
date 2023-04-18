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
            print("cortaste el cofre. ganaste 15 pesos");
            AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
            Destroy(gameObject);
            wasCut = true;
        }
    }
}
