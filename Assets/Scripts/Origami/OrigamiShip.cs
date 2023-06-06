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
        barquito.SetActive(true);
        //soniditos y particulas de puente spawneado
    }
}
