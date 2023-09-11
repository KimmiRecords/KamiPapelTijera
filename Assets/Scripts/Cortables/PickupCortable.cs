using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        StartCoroutine(WaitForSelfDestructCoroutine(selfDestructTime));

        if (doesRespawn)
        {
            StartCoroutine(WaitForRespawnCoroutine(respawnTime));
        }
    }

    protected void Respawn()
    {
        //print("respawn");
        //apago las partes y prendo el entero
        ReunirSprites();
        isCortable = true;
    }

    protected void ReunirSprites()
    {
        spriteEntero.gameObject.SetActive(true);
        spriteBase.gameObject.SetActive(false);
        spriteTop.gameObject.transform.position = posicionInicial;
        spriteTop.gameObject.SetActive(false);
    }

    protected IEnumerator WaitForSelfDestructCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        spriteTop.gameObject.transform.gameObject.SetActive(false);
    }

    protected IEnumerator WaitForRespawnCoroutine(float time)
    {
        //print("delayed respawn");
        yield return new WaitForSeconds(time);
        Respawn();
    }

    public void Aplastar()
    {
        Debug.Log("este cortable fue aplastado");
        ApplyCut();
    }


    //una pregunta copada:
    //puedo generalizar estas corrutinas WaitForX usando lambdas o algo asi?
    //tal que me quede WaitForAction(metodo, tiempo)


}
