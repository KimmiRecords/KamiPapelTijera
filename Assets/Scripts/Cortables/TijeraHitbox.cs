using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TijeraHitbox : MonoBehaviour
{
    //la tijera necesita collider (trigger)
    //cuando toca a algo ICortable, adivina? si, lo corta. 

    public float tijeraDamage = 50;
    bool missed;

    private void OnTriggerEnter(Collider other)
    {
        //print("entre a un collider...");
        if (other.GetComponent<ICortable>() != null)
        {
            //print("...cortable");
            ICortable objetoCortable = other.GetComponent<ICortable>();
            objetoCortable.GetCut(tijeraDamage);
            missed = false;
        }
        else
        {
            missed = true;
        }
    }

    private void OnDisable()
    {
        if (missed)
        {
            AudioManager.instance.PlayByName("TijeraMiss", 1.1f);
            missed = false;
        }
    }
}
