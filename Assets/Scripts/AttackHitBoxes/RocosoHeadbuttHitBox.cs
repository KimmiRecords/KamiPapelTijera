using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocosoHeadbuttHitBox : MonoBehaviour
{
    [HideInInspector]
    public float headbuttDamage;

    private void OnTriggerEnter(Collider other)
    {
        //print("entre a un collider...");
        if (other.GetComponent<IGolpeable>() != null) //normalmente lo unico golpeable es Kami xd
        {
            //print("...golpeable");

            IGolpeable objetoGolpeable = other.GetComponent<IGolpeable>();
            objetoGolpeable.GetGolpeado(headbuttDamage);
        }
    }
}
