using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : TriggerScript, ICortable
{
    [SerializeField]
    Vector3 rotationVector;

    public void GetCut()
    {
        print("me cortaron");
        transform.Rotate(rotationVector);
    }

    public override void Interact(params object[] parameter)
    {
        if (triggerBool)
        {
            GetCut();
        }
    }

}
