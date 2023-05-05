using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCortable : MonoBehaviour, ICortable
{
    public void GetCut(float dmg)
    {
        print("cortaste la puerta");
        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");

        //TooltipManager.instance.HideTooltip();
        Destroy(gameObject);
    }
}
