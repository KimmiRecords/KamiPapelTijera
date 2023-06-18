using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaCortable : FlorCortable
{
    [SerializeField]
    int curacionAmount = 20;

    public override void GetCut(float dmg)
    {
        if (isCortable)
        {
            //print("cortaste este arbusto");
            AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
            AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");

            //apago el entero y prendo las partes
            spriteEntero.gameObject.SetActive(false);
            spriteBase.gameObject.SetActive(true);
            pickupRB.gameObject.SetActive(true);

            //el pickup pega saltito y cae wujuuuu
            spritePickup.Jump();

            //en vez de delayedspawn, tendria que ser instapickup
            //StartDelayedRespawn();
            LevelManager.instance.CurePlayer(curacionAmount);
            AudioManager.instance.PlayByName("Pickup", 0.8f);

            isCortable = false;

        }
    }
}
