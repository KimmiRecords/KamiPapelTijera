using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpritePickup : TriggerScript
{
    //los sprite pickups se llaman pickups xq en un principio la idea
    //era que estos caian cortados y luego habia que tocarlos para agarrarlos.
    //ahora, simplemente caen y desaparecen
    //(se añade al inventario al momento de cortar,
    //no hace falta tocarlo de nuevo)

    [SerializeField]
    protected bool haceSaltito; //si pega saltito al nacer como un pickup de flor

    [SerializeField]
    protected FlorCortable miCortable;

    protected Vector3 originalPosition;
    protected Quaternion originalQuaternion;
    protected bool isReadyToJump = true;
    protected bool isReadyToPickup;


    public bool isSelfDestruct;
    public float timeUntilSelfdestruct = 2;


    protected override void Start()
    {
        base.Start();
        originalPosition = transform.position;
        originalQuaternion = transform.rotation;
        miCortable.pickupRB.AddForce(GetRandomJumpDir() * miCortable.jumpForce);
    }

    public virtual void ResetPosition()
    {
        //print("reset position");
        //vuelvo a donde empece
        transform.SetPositionAndRotation(originalPosition, originalQuaternion);
        isReadyToJump = true;
    }

    public virtual void Jump()
    {
        //print("el pickup salta");
        //nace tirando animacion de salir volando y caer al piso. 
        if (haceSaltito)
        {
            if (isReadyToJump)
            {
                //Debug.Log("aaaaaa");
                miCortable.pickupRB.AddForce(GetRandomJumpDir() * miCortable.jumpForce);
                //transform.position += new Vector3(1, 1, 1);

                isReadyToJump = false;
            }
        }

        if (isSelfDestruct)
        {
            StartCoroutine(SelfDestructCoroutine(timeUntilSelfdestruct));
        }

        //esta linea esta comentada porque al final los pickups son autopickupeables
        //cuestion que nunca voy a tener que pickupear estas cosas del piso
        //isReadyToPickup = true;
    }

    public Vector3 GetRandomJumpDir()
    {
        float randomX;
        if (Random.Range(0, 100) < 50)
        {
            randomX = -1;
        }
        else
        {
            randomX = 1;
        }

        return new(randomX, 1, randomX);
    }

    public IEnumerator SelfDestructCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        transform.parent.gameObject.SetActive(false);
        //Destroy(gameObject);
    }


}
