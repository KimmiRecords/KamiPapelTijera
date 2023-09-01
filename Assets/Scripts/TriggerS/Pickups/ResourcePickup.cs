using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickup : SpritePickup
{
    //los sprite pickup son por ejemplo los hongos, las flores o las hojas
    //normalmente va junto al sprite top y su collider

    protected ResourceType pickupType;
    protected int pickupAmount;

}
