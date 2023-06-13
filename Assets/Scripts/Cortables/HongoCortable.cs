using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongoCortable : FlorCortable
{
    //los hongos estan en las cabezas de las gallinas
    //asi que nacen, saltan, se deshacen hijos de la gallina

    //los hongos no respawnean

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
            pickupRB.gameObject.transform.parent = null;

            //el pickup pega saltito y cae wujuuuu
            spritePickup.Jump();

            isCortable = false;
        }
    }

    public override void Respawn()
    {
        print("jkajajajjaj");
    }
}


