using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol2DTrigger : TriggerScript
{
    //la idea del arbol2d es que aplasta

    protected override void OnTriggerEnter(Collider other)
    {
        //base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<IAplastable>() != null)
        {
            other.gameObject.GetComponent<IAplastable>().Aplastar();
        }
    }
}
