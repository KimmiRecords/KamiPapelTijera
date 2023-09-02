using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaCortable : PickupCortable
{
    [SerializeField] int curacionAmount = 20;

    protected override void ApplyCut()
    {
        base.ApplyCut();
        LevelManager.Instance.AddHealth(curacionAmount);
    }
}
