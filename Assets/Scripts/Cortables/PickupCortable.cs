using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupCortable : ObjetoCortable, IAplastable
{
    //los pickups cortables dan algun recurso, 
    //desaparecen despues de cortarlos,
    //y pueden respawnear

    [SerializeField] protected ResourceType pickupType;
    [SerializeField] protected int pickupAmount;

    protected override void ApplyCut()
    {
        base.ApplyCut();

        EventManager.Trigger(Evento.OnObjectWasCut, transform.position);
        
        LevelManager.Instance.AddResource(pickupType, pickupAmount);
        StartCoroutine(WaitForActionCoroutine(selfDestructTime, SelfDestruct));

        if (doesRespawn)
        {
            StartCoroutine(WaitForActionCoroutine(respawnTime, Respawn));
        }
    }
    public void Aplastar()
    {
        Debug.Log("este cortable fue aplastado");
        ApplyCut();
    }
}
