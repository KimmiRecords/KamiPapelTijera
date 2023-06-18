using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPickup : SpritePickup
{
    //los vida pickup cuando los tocas te dan vida. y si.


    public override void OnEnterBehaviour(Collider other)
    {
        //print("on enter behaviour por " + other.gameObject.name);

        //if (isReadyToPickup)
        //{
        //    print("estaba ready to pickup");
        //    base.OnEnterBehaviour(other);

        //    if (other.GetComponent<ICurable>() != null )
        //    {
        //        ICurable curable = other.GetComponent<ICurable>();
        //        curable.GetCured(vidaReward);
        //        AudioManager.instance.PlayByName("Pickup", 0.666f);
        //        print("tuki, curado. vida + " + vidaReward);
        //    }

        //    AudioManager.instance.PlayByName("Pickup");
        //    miCortable.StartDelayedRespawn();
        //    isReadyToPickup = false;
        //    ResetPosition();
        //    miCortable.pickupRB.gameObject.SetActive(false);
        //}
    }
}
