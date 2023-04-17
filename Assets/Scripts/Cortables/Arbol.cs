using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour, ICortable
{
    [SerializeField]
    Vector3 rotationVector;

    [SerializeField]
    Vector3 newPosition;

    bool wasCut = false;

    public void GetCut(float dmg)
    {
        if (!wasCut)
        {
            print("me cortaron");
            AudioManager.instance.PlayByName("ShipCrash");
            transform.Rotate(rotationVector);
            transform.localPosition = newPosition;
            wasCut = true;
        }
    }

}
