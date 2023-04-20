using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView
{
    public void StartTijeraAnimation()
    {
        AudioManager.instance.PlayByName("TijeraMiss", 1.1f);
    }

    public void StartGetWetAnimation()
    {
        AudioManager.instance.PlayByName("ShipCrash", 0.4f);
    }

    public void StartGetGolpeadoAnimation()
    {
        AudioManager.instance.PlayByName("ShipCrash", 0.75f);
    }
}
