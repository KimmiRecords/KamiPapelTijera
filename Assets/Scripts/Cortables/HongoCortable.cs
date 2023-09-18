using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongoCortable : PickupCortable
{
    //el hongo cortable debe cambiar la animacion de la gallina
    [SerializeField] Animator _anim;

    protected override void ApplyCut()
    {
        print("cortaste el hongo!");
        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
        AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");
        AudioManager.instance.PlayByName("MagicSuccess", 2f);


        //cambio las animaciones
        _anim.SetBool("_isCortado", true);

        isCortable = false;
        LevelManager.Instance.AddResource(pickupType, pickupAmount);
        StartCoroutine(WaitForActionCoroutine(selfDestructTime, SelfDestruct));

        if (doesRespawn)
        {
            StartCoroutine(WaitForActionCoroutine(respawnTime, Respawn));
        }
    }
}


