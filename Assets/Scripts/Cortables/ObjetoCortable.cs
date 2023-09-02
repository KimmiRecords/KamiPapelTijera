using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCortable : MonoBehaviour, ICortable
{
    //los objetosCortables se pueden partir en dos
    //tiene que tener sus sprites en entero y en dividido. 
    //este script apaga uno y prende los otros cuando es cortado

    [SerializeField] protected SpriteRenderer spriteEntero, spriteBase, spriteTop;
    protected bool isCortable = true;

    public float velocidadInicial = 5.0f;
    public float anguloLanzamiento = 45.0f; // Ángulo en grados

    protected Vector3 posicionInicial;
    protected float tiempoDeVuelo;
    protected readonly float gravedad = 9.81f;

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
        print("cortaste este objeto");
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


    protected IEnumerator MoverEnTiroOblicuo()
    {
        float tiempoPasado = 0.0f;
        tiempoDeVuelo = (2 * velocidadInicial * Mathf.Sin(anguloLanzamiento * Mathf.Deg2Rad)) / gravedad;

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

}
