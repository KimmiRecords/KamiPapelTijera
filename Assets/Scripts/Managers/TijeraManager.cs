using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TijeraType
{
    Normal,
    Mejorada
}

public class TijeraManager : MonoBehaviour
{
    //este script se encarga de ponerle la tijera correcta a kami
    //le cargas las hitbox y listo

    public TijeraHitbox tijeraHitbox;
    public TijeraHitbox tijeraMejoradaHitbox;

    public ParticleSystem tijeraParticles, tijeraTrail, tijeraMejoradaParticles, tijeraMejoradaTrail;

    TijeraType currentTijera;

    public void SetTijera(params object[] parameters)
    {
        //Debug.Log("prendo la tijera");
        tijeraHitbox.transform.parent.gameObject.SetActive(true);
        currentTijera = TijeraType.Normal;
    }

    public void SetTijeraMejorada(params object[] parameters)
    {
        //Debug.Log("prendo la tijera mejorada");
        tijeraHitbox.transform.parent.gameObject.SetActive(false);
        tijeraMejoradaHitbox.transform.parent.gameObject.SetActive(true);
        currentTijera = TijeraType.Mejorada;
    }

    public void EnableTijeraParticles()
    {
        switch (currentTijera)
        {
            case TijeraType.Normal:
                tijeraParticles.gameObject.SetActive(true);
                break;
            case TijeraType.Mejorada:
                tijeraMejoradaParticles.gameObject.SetActive(true);
                break;
        }
    }

    public void DisableTijeraParticles()
    {
        switch (currentTijera)
        {
            case TijeraType.Normal:
                tijeraParticles.gameObject.SetActive(false);
                break;
            case TijeraType.Mejorada:
                tijeraMejoradaParticles.gameObject.SetActive(false);
                break;
        }
    }

    public void SetTrailRadius(float newRadius)
    {
        ParticleSystem.ShapeModule shape = tijeraTrail.shape;
        shape.radius = newRadius;
    }
}
