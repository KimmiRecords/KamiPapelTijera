using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbustoCortable : FlorCortable
{
    public float velocidadInicial = 5.0f;
    public float anguloLanzamiento = 45.0f; // Ángulo en grados

    Vector3 posicionInicial;
    float tiempoDeVuelo;
    readonly float gravedad = 9.81f;

    void Start()
    {
        posicionInicial = spriteTop.gameObject.transform.localPosition;
        
        //calculo el tiempo que me tomaria todo este saltito
        float radianes = anguloLanzamiento * Mathf.Deg2Rad;
        tiempoDeVuelo = (2 * velocidadInicial * Mathf.Sin(radianes)) / gravedad;
    }

    public override void GetCut(float dmg)
    {
        if (isCortable)
        {
            print("cortaste este objeto");
            AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
            AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");

            //apago el entero y prendo las partes
            spriteEntero.gameObject.SetActive(false);
            spriteBase.gameObject.SetActive(true);
            spriteTop.gameObject.SetActive(true);

            //el pickup pega saltito y cae wujuuuu
            StartCoroutine(MoverEnTiroOblicuo());
            isCortable = false;
        }
    }

    IEnumerator MoverEnTiroOblicuo()
    {
        float tiempoPasado = 0.0f;

        while (tiempoPasado < tiempoDeVuelo)
        {
            float x = posicionInicial.x + (velocidadInicial * Mathf.Cos(anguloLanzamiento * Mathf.Deg2Rad)) * tiempoPasado;
            float y = posicionInicial.y + (velocidadInicial * Mathf.Sin(anguloLanzamiento * Mathf.Deg2Rad)) * tiempoPasado - (0.5f * gravedad * tiempoPasado * tiempoPasado);
            float z = posicionInicial.z + (velocidadInicial * Mathf.Cos(anguloLanzamiento * Mathf.Deg2Rad)) * tiempoPasado;

            spriteTop.gameObject.transform.localPosition = new Vector3(x, y, -z);
            Debug.Log(spriteTop.gameObject.transform.localPosition);

            tiempoPasado += Time.deltaTime;
            yield return null;
        }
    }

    //faltaria que desaparezca
    //(en el caso de los arbustos, que respawnee)
    //y poder ajustar el movimiento en z (para hacer el caso del arbol despues)





















    ////el arbusto, a diferencia de la flor, respawnea
    //public override void GetCut(float dmg)
    //{
    //    if (isCortable)
    //    {
    //        //print("cortaste este arbusto");
    //        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
    //        AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");

    //        //apago el entero y prendo las partes
    //        spriteEntero.gameObject.SetActive(false);
    //        spriteBase.gameObject.SetActive(true);
    //        pickupRB.gameObject.SetActive(true);

    //        //el pickup pega saltito y cae wujuuuu
    //        spritePickup.Jump();

    //        //en vez de delayedspawn, tendria que ser instapickup
    //        StartDelayedRespawn();
    //        LevelManager.Instance.AddResource(pickupType, pickupAmount);
    //        AudioManager.instance.PlayByName("PickupSFX");

    //        isCortable = false;
    //        //_isCortado = true;
    //    }
    //}
}
