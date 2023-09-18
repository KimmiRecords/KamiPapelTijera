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

    [SerializeField] protected bool doesRespawn;
    [SerializeField] protected float respawnTime = 30;

    protected float selfDestructTime = 1;

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
    protected void Respawn()
    {
        //print("respawn");
        //apago las partes y prendo el entero
        ReunirSprites();
        isCortable = true;
    }
    protected void SelfDestruct()
    {
        //Debug.Log("selfdestruct");
        spriteTop.gameObject.transform.gameObject.SetActive(false);
    }
    protected void ReunirSprites()
    {
        spriteEntero.gameObject.SetActive(true);
        spriteBase.gameObject.SetActive(false);
        spriteTop.gameObject.transform.position = posicionInicial;
        spriteTop.gameObject.SetActive(false);
    }

    protected IEnumerator WaitForActionCoroutine(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}
