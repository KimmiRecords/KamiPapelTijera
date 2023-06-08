using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiShip : Origami
{
    //este script va en la RUTA, no en el objeto barco

    [SerializeField]
    GameObject barquito;

    public override void Apply()
    {
        base.Apply();
        barquito.SetActive(true);
        AudioManager.instance.PlayByName("ShipSpawn");

        //soniditos y particulas de puente spawneado
    }
}
