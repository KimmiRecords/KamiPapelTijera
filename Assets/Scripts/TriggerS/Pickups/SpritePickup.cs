using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpritePickup : TriggerScript
{

    [SerializeField]
    protected float jumpForce;
    [SerializeField]
    protected bool haceSaltito; //si pega saltito al nacer como un pickup de flor

    [SerializeField]
    protected ObjetoCortable miCortable;


    protected Vector3 originalPosition;
    protected Quaternion originalQuaternion;
    protected bool isReadyToJump;
    protected bool isReadyToPickup;


    protected override void Start()
    {
        base.Start();
        originalPosition = transform.position;
        originalQuaternion = transform.rotation;
        miCortable.pickupRB.AddForce(new Vector3(1, 1, 1) * jumpForce);
        //transform.position += new Vector3(1, 1, 1);
    }

    public void ResetPosition()
    {
        //print("reset position");
        //vuelvo a donde empece
        transform.SetPositionAndRotation(originalPosition, originalQuaternion);
        isReadyToJump = true;
    }

    public void Jump()
    {
        print("la flor salta");
        //nace tirando animacion de salir volando y caer al piso. 
        if (haceSaltito)
        {
            if (isReadyToJump)
            {
                miCortable.pickupRB.AddForce(new Vector3(1, 1, 1) * jumpForce);
                //transform.position += new Vector3(1, 1, 1);
                isReadyToJump = false;
            }
        }

        isReadyToPickup = true;
    }

}
