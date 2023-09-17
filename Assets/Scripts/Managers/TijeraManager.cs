using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TijeraManager : MonoBehaviour
{
    //este script se encarga de ponerle la tijera correcta a kami
    //le cargas las hitbox y listo

    public TijeraHitbox tijeraHitbox;
    public TijeraHitbox tijeraMejoradaHitbox;

    public void SetTijera(params object[] parameters)
    {
        Debug.Log("prendo la tijera");
        tijeraHitbox.transform.parent.gameObject.SetActive(true);
    }

    public void SetTijeraMejorada(params object[] parameters)
    {
        Debug.Log("prendo la tijera mejorada");
        tijeraHitbox.transform.parent.gameObject.SetActive(false);
        tijeraMejoradaHitbox.transform.parent.gameObject.SetActive(true);
    }
}
