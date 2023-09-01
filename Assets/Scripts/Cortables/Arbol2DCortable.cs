using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol2DCortable : FlorCortable
{
    public override void GetCut(float dmg)
    {
        if (isCortable)
        {
            Debug.Log("arbol2d get cut");
            AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
            AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");

            spriteEntero.gameObject.SetActive(false);
            spriteBase.gameObject.SetActive(true);
            pickupRB.gameObject.SetActive(true);

            spritePickup.Jump();

            LevelManager.Instance.AddResource(pickupType, pickupAmount);
            AudioManager.instance.PlayByName("QuestCompleted", 0.85f);
            isCortable = false;
        }
    }
}
