using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongoPickup : ResourcePickup
{
    //el hongo pickup es un resource pickup que re-spawnea en la cabeza de su gallina


    public override void ResetPosition()
    {
        //print("reset position");
        //vuelvo a donde empece
        miCortable.pickupRB.transform.parent = miCortable.transform;
        transform.SetPositionAndRotation(originalPosition, originalQuaternion);
        isReadyToJump = true;
    }
}
