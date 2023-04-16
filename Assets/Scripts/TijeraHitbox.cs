using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TijeraHitbox : MonoBehaviour
{
    //la tijera necesita collider (trigger)
    //cuando toca a algo ICortable, adivina? si, lo corta. 

    [HideInInspector]
    public float tijeraDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ICortable>() != null)
        {
            ICortable objetoCortable = other.GetComponent<ICortable>();
            objetoCortable.GetCut(tijeraDamage);
        }
    }

    
}
