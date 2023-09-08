using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandadoCortable : PickupCortable
{
    //el candado dispara la animacion de abrir de un cofreCortable cuando lo corto.
    //[SerializeField] protected float timeUntilDestroy = 5;

    [SerializeField] protected CofreCortable cofreQueAbro;

    protected override void ApplyCut()
    {
        base.ApplyCut();
        cofreQueAbro.OpenChest();
    }
}
