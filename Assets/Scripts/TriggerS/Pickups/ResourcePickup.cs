using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickup : SpritePickup
{
    //los sprite pickup son por ejemplo los hongos, las flores o las hojas

    protected ResourceType pickupType;
    protected int pickupAmount;

    public override void OnEnterBehaviour(Collider other)
    {


        //print("on enter behaviour por " + other.gameObject.name);

        //if (isReadyToPickup) //esto no deberia suceder nunca igual 
        //{
        //    print("estaba ready to pickup");
        //    base.OnEnterBehaviour(other);

        //    LevelManager.instance.AddResource(pickupType, pickupAmount);
        //    AudioManager.instance.PlayByName("Pickup");

        //    miCortable.StartDelayedRespawn();
        //    isReadyToPickup = false;
        //    ResetPosition();
        //    miCortable.pickupRB.gameObject.SetActive(false);
        //}
    }
}
