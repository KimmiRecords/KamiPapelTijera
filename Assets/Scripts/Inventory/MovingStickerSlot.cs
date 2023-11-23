using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStickerSlot : InventorySlot
{
    private void Update()
    {
        //move upwards
        transform.position += Vector3.up * Time.deltaTime * upwardsSpeed;
    }
}
