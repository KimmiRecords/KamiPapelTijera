using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjetoCortable : MonoBehaviour, ICortable
{
    //los objetosCortables se pueden partir en dos
    //tiene que tener sus sprites en entero y en dividido. 
    //este script apaga uno y prende los otros cuando es cortado

    [SerializeField] protected SpriteRenderer spriteEntero, spriteBase, spriteTop;

    [SerializeField] protected float velocidadInicial = 5.0f;
    [SerializeField] protected float anguloLanzamiento = 45.0f; // Ángulo en grados
    [SerializeField] protected float alturaInicial = 0;

    protected bool isCortable = true;
    protected Vector3 posicionInicial;
    protected float tiempoDeVuelo;
    protected readonly float gravedad = 9.81f;

    [SerializeField] protected bool doesRespawn;
    [SerializeField] protected float respawnTime = 30;

    protected float selfDestructTime = 1;

    protected void Start()
    {
        posicionInicial = spriteTop.gameObject.transform.localPosition;

        //calculo el tiempo que me tomaria todo este saltito
    }

    public virtual void GetCut(float dmg)
    {
        if (isCortable)
        {
            ApplyCut();
        }
    }

    protected virtual void ApplyCut()
    {
        //print("cortaste este objeto");
        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
        AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");

        //apago el entero y prendo las partes
        SepararSprites();

        //el pickup pega saltito y cae wujuuuu
        StartCoroutine(MoverEnTiroOblicuo());
        isCortable = false;
    }

    protected void SepararSprites()
    {
        spriteEntero.gameObject.SetActive(false);
        spriteBase.gameObject.SetActive(true);
        spriteTop.gameObject.SetActive(true);
    }


    protected virtual IEnumerator MoverEnTiroOblicuo()
    {
        float tiempoPasado = 0.0f;
        tiempoDeVuelo = (2 * velocidadInicial * Mathf.Sin(anguloLanzamiento * Mathf.Deg2Rad)) / gravedad;

        while (tiempoPasado < tiempoDeVuelo)
        {
            float x = posicionInicial.x + (velocidadInicial * Mathf.Cos(anguloLanzamiento * Mathf.Deg2Rad)) * tiempoPasado;
            float y = alturaInicial + posicionInicial.y + (velocidadInicial * Mathf.Sin(anguloLanzamiento * Mathf.Deg2Rad)) * tiempoPasado - (0.5f * gravedad * tiempoPasado * tiempoPasado);
            float z = posicionInicial.z + (velocidadInicial * Mathf.Cos(anguloLanzamiento * Mathf.Deg2Rad)) * tiempoPasado;

            spriteTop.gameObject.transform.localPosition = new Vector3(x, y, -z);
            //Debug.Log(spriteTop.gameObject.transform.localPosition);

            tiempoPasado += Time.deltaTime;
            yield return null;
        }
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
