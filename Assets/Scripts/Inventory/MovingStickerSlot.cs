using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStickerSlot : InventorySlot
{
    [SerializeField] float upwardsSpeed = 1f;

    private void Update()
    {
        //move upwards
        transform.position += Vector3.up * Time.deltaTime * upwardsSpeed;
    }

    

}
