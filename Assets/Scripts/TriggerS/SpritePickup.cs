using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePickup : TriggerScript
{
    //los sprite pickup son por ejemplo los hongos, las flores o las hojas

    [SerializeField]
    ResourceType pickupType;
    [SerializeField]
    int pickupAmount;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    bool haceSaltito; //si pega saltito al nacer como un pickup de flor

    [SerializeField]
    FlorCortable miCortable;
    

    Vector3 originalPosition;
    Quaternion originalQuaternion;
    private bool isReadyToJump;
    private bool isReadyToPickup;


    protected override void Start()
    {
        base.Start();
        originalPosition = transform.position;
        originalQuaternion = transform.rotation;
        miCortable.pickupRB.AddForce(new Vector3(1, 1, 1) * jumpForce);
        //transform.position += new Vector3(1, 1, 1);
    }

    public override void OnEnterBehaviour(Collider other)
    {
        print("la flor on enter behaviour por " + other.gameObject.name);

        if (isReadyToPickup)
        {
            print("estaba ready to pickup");
            base.OnEnterBehaviour(other);
            LevelManager.instance.AddResource(pickupType, pickupAmount);
            AudioManager.instance.PlayByName("Pickup");
            miCortable.StartDelayedRespawn();
            isReadyToPickup = false;
            ResetPosition();
            miCortable.pickupRB.gameObject.SetActive(false);
        }
    }

    public void ResetPosition()
    {
        print("la flor reset position");

        //vuelvo a donde empece
        transform.position = originalPosition;
        transform.rotation = originalQuaternion;
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
